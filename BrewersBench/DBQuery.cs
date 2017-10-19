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
        /// Returns the result of a query for all database Ingredients.
        /// </summary>
        /// <returns></returns>
        public List<Potion> queryPotions()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Potion", connection);
            DataTable potionsTable = new DataTable();
            adapter.Fill(potionsTable);
            DataRowCollection rows = potionsTable.Rows;

            List<Potion> potions = new List<Potion>();
            foreach(DataRow dr in rows)
            {
                object[] data = dr.ItemArray;
                List<Effect> associatedEffects = queryEffectsByForeignKeyAndType("Potion", (int)data[0]);
                Potion p = new Potion((int)data[0], (string)data[1], Convert.ToSingle(data[2]), (int)data[3], (Usage)data[4], associatedEffects);
                potions.Add(p);
            }
            connection.Close();
            return potions;
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

        /// <summary>
        /// Inserts the given Vessel into the Database.
        /// </summary>
        /// <param name="v"></param>
        public void InsertNewVessel(Vessel v)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "INSERT INTO Vessel output INSERTED.Id VALUES (@Name, @Doses, @Usage, @Radius)"; 
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", v.name);
            command.Parameters.AddWithValue("@Doses", v.doses);
            command.Parameters.AddWithValue("@Usage", (int)v.usage);
            command.Parameters.AddWithValue("@Radius", v.radius);
            int id = (int)command.ExecuteScalar();
            connection.Close();
        }

        /// <summary>
        /// Inserts the given Base into the Database.
        /// </summary>
        /// <param name="b"></param>
        public void InsertNewBase(Base b)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "INSERT INTO Base output INSERTED.Id VALUES (@Name, @Volatility, @DosageMod)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", b.name);
            command.Parameters.AddWithValue("@Volatility", b.volatility);
            command.Parameters.AddWithValue("@DosageMod", b.dosageMod);
            int id = (int)command.ExecuteScalar();
            connection.Close();
            insertNewEffects(b.baseEffects, "BaseId", id);
        }

        /// <summary>
        /// Inserts the given Ingredient into the Database.
        /// </summary>
        /// <param name="i"></param>
        public void InsertNewIngredient(Ingredient i)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "INSERT INTO Ingredient output INSERTED.Id VALUES (@Name, @Volatility)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", i.name);
            command.Parameters.AddWithValue("@Volatility", i.volatility);
            int id = (int)command.ExecuteScalar();
            connection.Close();
            insertNewEffects(i.ingredientEffects, "IngredientId", id);
        }

        /// <summary>
        /// Inserts the given Potion into the Database.
        /// </summary>
        /// <param name="p"></param>
        public void InsertNewPotion(Potion p)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "INSERT INTO Potion output INSERTED.Id VALUES (@Name,@Doses, @Volatility, @Usage)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", p.getName());
            command.Parameters.AddWithValue("@Doses", p.getDoses());
            command.Parameters.AddWithValue("@Volatility", p.getVolatility());
            command.Parameters.AddWithValue("@Usage", (int)p.getUsage());
            int id = (int)command.ExecuteScalar();
            connection.Close();
            insertNewEffects(p.getEffects(), "PotionId", id);
        }

        /// <summary>
        /// /Inserts a list of effects into the Database.
        /// </summary>
        /// <param name="effects"></param>
        public void insertNewEffects(List<Effect> effects, string typeId, int id)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            string queryIdSubstring = "";
            switch(typeId)
            {
                case "BaseId":
                    queryIdSubstring = "@BaseId, NULL, NULL";
                    break;
                case "IngredientId":
                    queryIdSubstring = "NULL, @IngredientId, NULL";
                    break;
                case "PotionId":
                    queryIdSubstring = "NULL, NULL, @PotionId";
                    break;
            }

            foreach(Effect e in effects)
            {
                string query = "";
                EffectType type = e.getEffectEnumType();
                SqlCommand command;
                switch (type)
                {
                    case EffectType.NONE:
                        NoEffect ne = (NoEffect)e;
                        query = "INSERT INTO Effect VALUES(@Name, @EffectType, NULL, NULL, NULL, " + queryIdSubstring + ", NULL)";
                        Console.WriteLine(query);
                        command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Name", ne.name);
                        command.Parameters.AddWithValue("@EffectType", (int)type);
                        command.Parameters.AddWithValue("@" + typeId, id);
                        command.ExecuteNonQuery();
                        break;

                    case EffectType.STAT:
                        StatEffect se = (StatEffect)e;
                        query = "INSERT INTO Effect VALUES(@Name, @EffectType, @StatType, NULL, NULL, " + queryIdSubstring + ", @Intensity)";
                        command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Name", se.name);
                        command.Parameters.AddWithValue("@EffectType", (int)type);
                        command.Parameters.AddWithValue("@StatType", (int)se.getAffectedStat());
                        command.Parameters.AddWithValue("@"+typeId, id);
                        command.Parameters.AddWithValue("@Intensity", se.getIntensity());
                        command.ExecuteNonQuery();
                        break;

                    case EffectType.BUFF:
                        BuffEffect be = (BuffEffect)e;
                        query = "INSERT INTO Effect VALUES(@Name, @EffectType, NULL, @BuffType, NULL, " + queryIdSubstring + ", @Intensity)";
                        command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Name", be.name);
                        command.Parameters.AddWithValue("@EffectType", (int)type);
                        command.Parameters.AddWithValue("@BuffType", (int)be.getBuff());
                        command.Parameters.AddWithValue("@" + typeId, id);
                        command.Parameters.AddWithValue("@Intensity", be.getIntensity());
                        command.ExecuteNonQuery();
                        break;

                    case EffectType.DEBUFF:
                        DebuffEffect de = (DebuffEffect)e;
                        query = "INSERT INTO Effect VALUES(@Name, @EffectType, NULL, NULL, @DebuffType, " + queryIdSubstring + ", @Intensity)";
                        command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Name", de.name);
                        command.Parameters.AddWithValue("@EffectType", (int)type);
                        command.Parameters.AddWithValue("@DebuffType", (int)de.getDebuff());
                        command.Parameters.AddWithValue("@" + typeId, id);
                        command.Parameters.AddWithValue("@Intensity", de.getIntensity());
                        command.ExecuteNonQuery();
                        break;
                }
            }
            connection.Close();
        }
    }
}
