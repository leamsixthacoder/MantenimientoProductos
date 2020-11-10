using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using CapaEntidades;
using System.Data;

namespace CapaDatos
{
    public class D_Categoria
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);



        public List<E_Categoria> ListarCategorias(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_BUSCARCATEGORIA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@BUSCAR", buscar);

            LeerFilas = cmd.ExecuteReader();

            List<E_Categoria> Listar = new List<E_Categoria>();

            while (LeerFilas.Read())
            {

                Listar.Add(new E_Categoria
                {
                    Idcategoria1 = LeerFilas.GetInt32(0),
                    Codigocategoria1 = LeerFilas.GetString(1),
                    Nombrecategoria1 = LeerFilas.GetString(2),
                    Descripcioncategoria1 = LeerFilas.GetString(3)
                });
            }

            conexion.Close();
            LeerFilas.Close();

            return Listar;

        }

        public void InsertarCategoria(E_Categoria Categoria)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTARCATEGORIA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@NOMBRE", Categoria.Nombrecategoria1);
            cmd.Parameters.AddWithValue("@DESCRIPCION", Categoria.Descripcioncategoria1);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EditarCategoria(E_Categoria Categoria)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITARCATEGORIA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@IDCATEGORIA", Categoria.Idcategoria1);
            cmd.Parameters.AddWithValue("@NOMBRE", Categoria.Nombrecategoria1);
            cmd.Parameters.AddWithValue("@DESCRIPCION", Categoria.Descripcioncategoria1);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EliminarCategoria(E_Categoria Categoria)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINARCATEGORIA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@IDCATEGORIA", Categoria.Idcategoria1);


            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
