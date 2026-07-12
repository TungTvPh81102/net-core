using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace CS37;

class Program
{
    static void ShowDataTable(DataTable table)
    {
        Console.WriteLine($"ten bang: {table.TableName}");
        Console.WriteLine($"index");
        foreach (DataColumn c in table.Columns)
        {
            Console.WriteLine(c.ColumnName);
        }

        Console.WriteLine();

        int number_cols = table.Columns.Count;

        int index = 0;

        foreach (DataRow r in table.Rows)
        {
            Console.WriteLine(index);
            for (int i = 0; i < number_cols; i++)
            {
                Console.WriteLine(r[i]);
            }

            Console.WriteLine();
            index++;
        }
    }

    static void Main(string[] args)
    {
        var sqlStringBuilder = new SqlConnectionStringBuilder();
        sqlStringBuilder.IntegratedSecurity = true;
        sqlStringBuilder.UserID = "sa";
        sqlStringBuilder.Password = "Password123";
        sqlStringBuilder["Server"] = "localhost,1433";
        sqlStringBuilder["Database"] = "iFactory";

        var sqlConnection = sqlStringBuilder.ToString();
        Console.WriteLine(sqlConnection);

        using var connection = new SqlConnection(sqlConnection);
        Console.WriteLine(connection.State);

        connection.Open();

        // truy van
        using DbCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "select * from TB_USER_INFO where id >= @account";

        var account = new SqlParameter("@account", 5);
        cmd.Parameters.Add(account);
        account.Value = 10; // thay gia tri cua account de where

        // ExecuteReader
        using var sqlReader = cmd.ExecuteReader();

        // if (sqlReader.HasRows)
        // {
        //     while (sqlReader.Read())
        //     {
        //         var id = sqlReader.GetInt32(0);
        //         var CREATE_TIME = sqlReader["CREATE_TIME"];
        //
        //         Console.WriteLine($"ID: {id} -  {CREATE_TIME}");
        //     }
        // }
        // else
        // {
        //     Console.WriteLine("no rows found");
        // }

        var datatable = new DataTable();
        datatable.Load(sqlReader);

        if (datatable.Rows.Count > 0)
        {
            foreach (DataRow row in datatable.Rows)
            {
                Console.WriteLine(row.ItemArray[0]);
            }
        }

        using var cmd2 = new SqlCommand();
        cmd2.Connection = connection;
        cmd2.CommandText = @"
                INSERT INTO TB_USER_PERMISSION
                (Permission, [Level], Module_ID)
                VALUES
                (@Permission,@Level,@Module_ID)";

        Random random = new Random();
        cmd2.Parameters.AddWithValue("@Permission", random.Next(1, 484848));
        cmd2.Parameters.AddWithValue("@Level", random.Next(1, 1546464));
        cmd2.Parameters.AddWithValue("@Module_ID", random.Next(1, 2151515));

        var kq = cmd2.ExecuteNonQuery();
        Console.WriteLine(kq);

        var dataset = new DataSet();
        var table = new DataTable("mytable");
        dataset.Tables.Add(table);

        table.Columns.Add("STT");
        table.Columns.Add("HoTen");
        table.Columns.Add("Tuoi");

        table.Rows.Add(1, "Truong Van Tung", 24);
        table.Rows.Add(1, "Tunny", 24);

        ShowDataTable(table);

        var adapter = new SqlDataAdapter();
        adapter.TableMappings.Add("Table", "CHECK");
        adapter.SelectCommand = new SqlCommand("SELECT top(10) * FROM TB_USER_PERMISSION", connection);
        adapter.InsertCommand = new SqlCommand(@"
            INSERT INTO TB_USER_PERMISSION
            (Permission,[Level],Module_ID)
            VALUES
            (@Permission,@Level,@Module_ID)", connection);
        adapter.InsertCommand.Parameters.Add("@Permission", SqlDbType.Int).SourceColumn = "Permission";
        adapter.InsertCommand.Parameters.Add("@Level", SqlDbType.Int).SourceColumn = "Level";
        adapter.InsertCommand.Parameters.Add("@Module_ID", SqlDbType.Int).SourceColumn = "Module_ID";

        adapter.DeleteCommand = new SqlCommand("DELETE FROM TB_USER_PERMISSION where id = @id", connection);
        var pr1 = adapter.DeleteCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
        pr1.SourceColumn = "id";
        pr1.SourceVersion = DataRowVersion.Original;
        
        

        var dataSet = new DataSet();
        adapter.Fill(dataSet); // đổ dữ liệu vào dataset
        DataTable tb = dataSet.Tables["CHECK"];
        ShowDataTable(tb);

        // var rows = tb.Rows.Add();
        // rows["permission"] = 9999;
        // rows["level"] = 1;
        // rows["module_id"] = 0000;


        var row10 = tb.Rows[9];
        row10.Delete();

        // update
        adapter.Update(dataSet);


        connection.Close();
    }
}

// sql server thuộc loại DataProvider 
// trong .net core là SqlClient ở namespace System.Data.SqlClient
// run sql co thể sử dụng: ExecuteNonQuery, ExecuteReader, ExecuteScalar

// ExecuteReader => dùng khi kết quả trả về có nhiều dòng
// ExecuteScalar => chỉ trả về 1 giá trị (dòng1 ,cột 1) => giống kiểu lấy select top
// ExecuteNonQuery => trả về tổng số dòng được tác động, sử dụng trong Insert, Update, Delete

// ExecuteReader => tra ve sqlReader => kiem ra co dữ liệu thông qua HasRows => đọc dữ liệu thông qua Read
// ExecuteReader => su dụng datatable để load dữ liệu

// Gọi store procedure
// Khởi tạo 1 procedure có name = userinfo
// cmd.commandText = "userinfo"
// cmd.commandType = commandType.StoredProcedure
// khởi tạo giá trị chuyền vào procedure 

// ADO.Net dùng DataAdapter, DataSet, DataTable
// table.Columns => chứa các cột dữ liệu => có kiểu DataColumn
// table.Rows => chưa các dòng dữ liệu trong bảng => có kiểu DataRow
// Datatable gồm => DataColumn, DataRow , TableCollection, ConstrainCollection

// DataAdapter => sẽ ánh xạ cột dữ liệu trong dataset trong csdl chỉ có 1 datable