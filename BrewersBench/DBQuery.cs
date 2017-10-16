using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace BrewersBench
{
    /// <summary>
    /// Handles Database SQL querying.
    /// </summary>
    class DBQuery
    {
        string connectionString;
        SqlConnection connection;

        /// <summary>
        /// Default DBQuery Constructor. Initializes the DB connection string. 
        /// </summary>
        public DBQuery()
        {
            connectionString = ConfigurationManager.ConnectionStrings["BrewersBench.Properties.Settings.BrewersBenchDBConnectionString"].ConnectionString;
        }
        
        /// <summary>
        /// Returns the result of a query for all database Vessels.
        /// </summary>
        /// <returns></returns>
        public List<Vessel> queryVessels()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Vessel", connection);
            DataTable vesselsTable = new DataTable();
            adapter.Fill(vesselsTable);
            DataRowCollection rows = vesselsTable.Rows;

            List<Vessel> vessels = new List<Vessel>();
            foreach (DataRow dr in rows)
            {
                object[] data = dr.ItemArray;
                Vessel v = new Vessel((int)data[0], (string)data[1], (int)data[2], (Usage)data[3], (int)data[4]);
                vessels.Add(v);
            }
            return vessels;
        }

        /// <summary>
        /// Returns the result of a query for all database Bases.
        /// </summary>
        /// <returns></returns>
        public List<Base> queryBases()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Base", connection);
            DataTable basesTable = new DataTable();
            adapter.Fill(basesTable);
            DataRowCollection rows = basesTable.Rows;
            List<Base> bases = new List<Base>();
            foreach (DataRow dr in rows)
            {
                object[] data = dr.ItemArray;
                List<Effect> associatedEffects = queryEffectsByForeignKeyAndType("Base", (int)data[0]);
                Base b = new Base((int)data[0], (string)data[1], (int)data[2], Convert.ToSingle(data[3]), associatedEffects);
                bases.Add(b);
            }
            return bases;
        }

        /// <summary>
        /// Returns the result of a query for all database Ingredients.
        /// </summary>
        /// <returns></returns>
        public List<Ingredient> queryIngredients()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Ingredient", connection);
            DataTable ingredientsTable = new DataTable();
            adapter.Fill(ingredientsTable);
            DataRowCollection rows = ingredientsTable.Rows;

            List<Ingredient> ingredients = new List<Ingredient>();
            foreach(DataRow dr in rows)
            {
                object[] data = dr.ItemArray;
                List<Effect> associatedEffects = queryEffectsByForeignKeyAndType("Ingredient", (int)data[0]);
                Ingredient i = new Ingredient((int)data[0], (string)data[1], (int)data[2], associatedEffects);
                ingredients.Add(i);
            }
            connection.Close();

            return ingredients;
        }

        /// <summary>
        /// Fetches all Effects associated with a specific Base, Ingredient, or Potion.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private List<Effect> queryEffectsByForeignKeyAndType(string type, int key)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Effect WHERE " + type + "Id = " + key, connection);
            DataTable associatedEffectsTable = new DataTable();

            adapter.Fill(associatedEffectsTable);
            DataRowCollection rows = associatedEffectsTable.Rows;
            List<Effect> effects = new List<Effect>();
            foreach(DataRow dr in rows)
            {
                object[] data = dr.ItemArray;
                EffectType et = (EffectType) data[2];
                switch(et)
                {
                    case EffectType.NONE:
                        effects.Add(new NoEffect((int)data[0]));
                        break;
                    case EffectType.STAT:
                        effects.Add(new StatEffect((int)data[0], (string)data[1], (ImbiberStat)data[3], (int)data[9]));
                        break;
                    case EffectType.BUFF:
                        effects.Add(new BuffEffect((int)data[0], (string)data[1], (ImbiberBuff)data[4], (int)data[9]));
                        break;
                    case EffectType.DEBUFF:
                        effects.Add(new DebuffEffect((int)data[0], (string)data[1], (ImbiberDebuff)data[5], (int)data[9]));
                        break;
                }
            }
            return effects;
        }
    }
}
