using CascadingDPWithCRUD.IRepository;
using CascadingDPWithCRUD.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ConfigurationManager = System.Configuration.ConfigurationManager;
using System.Drawing;

namespace CascadingDPWithCRUD.DAL
{
    public class DataAccessLayer: IEmployeeRepository
    {

        SqlConnection con = new SqlConnection(@"Server=DESKTOP-6NALV0L;Database=EmployeeDb;Trusted_Connection=True;");
        public string InsertData(Employee objcust)
            {
            string result = "";
                try
                {
                //con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
                // con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

                    SqlCommand cmd = new SqlCommand("sp_employee_ins_up", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@CustomerID", 0);    
                    cmd.Parameters.AddWithValue("@EmployeeId", objcust.EmployeeId);
                    cmd.Parameters.AddWithValue("@EmpName", objcust.EmpName);
                    cmd.Parameters.AddWithValue("@DepartmentId", objcust.DepartmentId);
                    cmd.Parameters.AddWithValue("@DesignationId", objcust.DesignationId);
                    cmd.Parameters.AddWithValue("@JoinDate", objcust.JoinDate);
                    cmd.Parameters.AddWithValue("@ContactNo", objcust.ContactNo);
                    cmd.Parameters.AddWithValue("@ActionType", 1);
                    con.Open();
                    result = cmd.ExecuteNonQuery().ToString();
                    return result;
                }
                catch
                {
                    return result = "";
                }
                finally
                {
                    con.Close();
                }
            }
        public string UpdateEmployee(Employee objempl)
        {
            string result = "";
            try
            {
                SqlCommand cmd = new SqlCommand("sp_employee_up", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeId", objempl.EmployeeId);
                cmd.Parameters.AddWithValue("@EmpName", objempl.EmpName);
                cmd.Parameters.AddWithValue("@DepartmentId", objempl.DepartmentId);
                cmd.Parameters.AddWithValue("@DesignationId", objempl.DesignationId);
                cmd.Parameters.AddWithValue("@JoinDate", objempl.JoinDate);
                cmd.Parameters.AddWithValue("@ContactNo", objempl.ContactNo);
                con.Open();
                result = cmd.ExecuteNonQuery().ToString();
                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }
        public string DeleteEmployee(int ID)
        {
            
            string result;
            try
            {
                //con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SP_Employee_del", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeId",ID);
                con.Open();
                result = cmd.ExecuteReader().ToString();
                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }



        public IEnumerable<Department> GetDepartment()
        {
            DataSet ds = null;
            List<Department>? emplist = null;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Deparment_sel", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                emplist = new List<Department>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Department cobj = new Department();
                    cobj.DepartmentId = Convert.ToInt32(ds.Tables[0].Rows[i]["DepartmentId"].ToString());
                    cobj.DeptName = ds.Tables[0].Rows[i]["DeptName"].ToString();
                    emplist.Add(cobj);
                }
                return emplist;
            }
            catch
            {
                return emplist;
            }
            finally
            {
                con.Close();
            }
        }

        public IEnumerable<Desination> GetDesination()
        {
            DataSet ds = null;
            List<Desination>? emplist = null;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Desination_sel", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                emplist = new List<Desination>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Desination cobj = new Desination();
                    cobj.DesignationId = Convert.ToInt32(ds.Tables[0].Rows[i]["DesignationId"].ToString());
                    cobj.DesinationName = ds.Tables[0].Rows[i]["DesinationName"].ToString();
                    emplist.Add(cobj);
                }
                return emplist;
            }
            catch
            {
                return emplist;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet GetDesinationList(int DepartmentId)
        {
            SqlCommand com = new SqlCommand("sp_DepartByDesination_Sel", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@DepartmentId", DepartmentId);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }


        public IEnumerable<Employee> GetEmployees()
        {
            DataSet ds = null;
            List<Employee>? emplist = null;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Employee_sel", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                emplist = new List<Employee>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Employee cobj = new Employee();
                    cobj.EmployeeId = Convert.ToInt32(ds.Tables[0].Rows[i]["EmployeeId"].ToString());
                    cobj.EmpName = ds.Tables[0].Rows[i]["EmpName"].ToString();
                    cobj.DepartmentId =Convert.ToInt32(ds.Tables[0].Rows[i]["DepartmentId"].ToString());
                    cobj.DeptName = ds.Tables[0].Rows[i]["DeptName"].ToString();
                    cobj.DesignationId = Convert.ToInt32(ds.Tables[0].Rows[i]["DesignationId"].ToString());
                    cobj.DesinationName = ds.Tables[0].Rows[i]["DesinationName"].ToString();
                    cobj.JoinDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["JoinDate"].ToString());
                    cobj.ContactNo = ds.Tables[0].Rows[i]["ContactNo"].ToString();

                    emplist.Add(cobj);
                }
                return emplist;
            }
            catch
            {
                return emplist;
            }
            finally
            {
                con.Close();
            }
        }




        public Employee GetEmployeeById(int EmployeeId)
        {
            DataSet ? ds = null;
            Employee ?cobj = null;
            try
            {
                //con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SP_EmployeGetById_Sel", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeId",EmployeeId);
                //cmd.Parameters.AddWithValue("@EmpName","");
                //cmd.Parameters.AddWithValue("@DepartmentId","");
                //cmd.Parameters.AddWithValue("@DesignationId","");
                //cmd.Parameters.AddWithValue("@JoinDate","");
                //cmd.Parameters.AddWithValue("@ContactNo","");
                //cmd.Parameters.AddWithValue("@ActionType",5);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    cobj = new Employee();
                    cobj.EmployeeId = Convert.ToInt32(ds.Tables[0].Rows[i]["EmployeeId"].ToString());
                    cobj.EmpName = ds.Tables[0].Rows[i]["EmpName"].ToString();
                    cobj.DepartmentId = Convert.ToInt32(ds.Tables[0].Rows[i]["DepartmentId"].ToString());
                    cobj.DeptName = ds.Tables[0].Rows[i]["DeptName"].ToString();
                    cobj.DesignationId = Convert.ToInt32(ds.Tables[0].Rows[i]["DesignationId"].ToString());
                    cobj.DesinationName = ds.Tables[0].Rows[i]["DesinationName"].ToString();
                    cobj.JoinDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["JoinDate"].ToString());
                    cobj.ContactNo = ds.Tables[0].Rows[i]["ContactNo"].ToString();

                }
                return cobj;
            }
            catch
            {
                return cobj;
            }
            finally
            {
                con.Close();
            }
        }



  

    }
}
