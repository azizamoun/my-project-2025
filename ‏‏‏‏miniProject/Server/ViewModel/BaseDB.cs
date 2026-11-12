using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Model;
namespace ViewModel
{
    public abstract class BaseDB
    {
        protected string connectionString;     //نص الاتصال
        protected OleDbConnection connection;  // كائن الاتصال
        protected OleDbCommand command;        //كائن الامر
        protected OleDbDataReader reader;     //كائن قراءة المعلومات
        protected List<BaseEntity> todoListInserts = new List<BaseEntity>();
        protected List<BaseEntity> todoListDeletes = new List<BaseEntity>();
        protected List<BaseEntity> todoListUpdates = new List<BaseEntity>();


        public BaseDB()
        {
            string path = Path();

            if (connectionString == null)
            {
                connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path() + "\\Database1.accdb;Persist Security Info=True";
            }
            connection = new OleDbConnection(connectionString);
            command = new OleDbCommand();
            command.Connection = connection;

        }


        protected void PrepareCommand(string sql)
        {
            command.Parameters.Clear();
            command.CommandText = sql;
        }

        protected int ReadInt(string column)
        {
            object value = reader[column];
            if (value == null || value == DBNull.Value)
                return 0;
            return Convert.ToInt32(value);
        }

        protected string ReadText(string column)
        {
            object value = reader[column];
            if (value == null || value == DBNull.Value)
                return string.Empty;
            return Convert.ToString(value);
        }

        protected List<BaseEntity> Select()
        {
            List<BaseEntity> list = new List<BaseEntity>();
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    BaseEntity entity = NewEntity();
                    list.Add(CreateModel(entity));
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
            return list;
        }
        protected abstract BaseEntity NewEntity();
        protected abstract BaseEntity CreateModel(BaseEntity entity);

        public virtual void Insert(BaseEntity entity)
        {
            BaseEntity reqEntity = NewEntity();
            if (entity != null && reqEntity.GetType() == entity.GetType())
                todoListInserts.Add(entity);
        }

        public virtual void Update(BaseEntity entity)
        {
            BaseEntity reqEntity = NewEntity();
            if (entity != null && reqEntity.GetType() == entity.GetType())
                todoListUpdates.Add(entity);
        }

        public virtual void Delete(BaseEntity entity)
        {
            BaseEntity reqEntity = NewEntity();
            if (entity != null && reqEntity.GetType() == entity.GetType())
                todoListDeletes.Add(entity);
        }

        public virtual string Savechanges()
        {
            try
            {
                connection.Open();
                foreach (var entity in todoListInserts)
                {
                    command.Parameters.Clear();
                    CreateInsertSql(entity);
                    command.ExecuteNonQuery();
                }
                foreach (var entity in todoListDeletes)
                {
                    command.Parameters.Clear();
                    CreateDeleteSql(entity);
                    command.ExecuteNonQuery();
                }
                foreach (var entity in todoListUpdates)
                {
                    command.Parameters.Clear();
                    CreateUpdateSql(entity);
                    command.ExecuteNonQuery();
                }

                todoListInserts.Clear();
                todoListDeletes.Clear();
                todoListUpdates.Clear();
                return "";
            }
            catch (Exception ex) { return ex.Message; }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }

        protected abstract void CreateInsertSql(BaseEntity entity);
        protected abstract void CreateUpdateSql(BaseEntity entity);
        protected abstract void CreateDeleteSql(BaseEntity entity);

        private static string Path()
        {
            string s = Environment.CurrentDirectory;   //exe address
            string[] ss = s.Split('\\');
            int x = ss.Length - 3;  //הורדתי 3 תיקיות מהסוף
            ss[x] = "ViewModel";
            Array.Resize(ref ss, x + 1);  //תיקון אורך המערך
            string s1 = String.Join("\\", ss);
            return s1;
        }
    }
}
