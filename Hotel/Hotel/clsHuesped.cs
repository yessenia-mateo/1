using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient|;

namespace Hotel
{
    public class clsHuesped
    {
        //CREACIÓN DE CAMPOS:
        private Int32 _idHuesped;
        private clsRuc _idRucH;
        private string _documentoIdentidadHuesped;
        private string _nombresHuesped;
        private string _apellidoPaternoHuesped;
        private string _apellidoMaternoHuesped;
        private DateTime _fechaNacimientoHuesped;
        private string _procedenciaHuesped;
        private bool _generoHuesped;

        //CREACIÓN DEL CONSTRUCTOR:
        public clsHuesped(string parametroDocumentoIdentidadHuesped,
                          string parametroNombresHuesped,
                          string parametroApellidoPaternoHuesped,
                          string parametroApellidoMaternoHuesped,
                          DateTime parametroFechaNacimientoHuesped,
                          string parametroProcedenciaHuesped,
                          bool parametroGeneroHuesped)
        {
            DocumentoIdentidadHuesped = parametroDocumentoIdentidadHuesped;
            NombresHuesped = parametroNombresHuesped;
            ApellidoPaternoHuesped = parametroApellidoPaternoHuesped;
            ApellidoMaternoHuesped = parametroApellidoMaternoHuesped;
            FechaNacimientoHuesped = parametroFechaNacimientoHuesped;
            ProcedenciaHuesped = parametroProcedenciaHuesped;
            GeneroHuesped = parametroGeneroHuesped;
        }

        //CREACIÓN DE PROPIEDADES:
        public Int32 IdHuesped
        {
            get { return _idHuesped; }
            set { _idHuesped = value; }
        }
        public clsRuc IdRucH
        {
            get { return _idRucH; }
            set { _idRucH = value; }
        }
        public string DocumentoIdentidadHuesped
        {
            get { return _documentoIdentidadHuesped; }
            set { _documentoIdentidadHuesped = value; }
        }
        public string NombresHuesped
        {
            get { return _nombresHuesped; }
            set { _nombresHuesped = value; }
        }
        public string ApellidoPaternoHuesped
        {
            get { return _apellidoPaternoHuesped; }
            set { _apellidoPaternoHuesped = value; }
        }
        public string ApellidoMaternoHuesped
        {
            get { return _apellidoMaternoHuesped; }
            set { _apellidoMaternoHuesped = value; }
        }
        public DateTime FechaNacimientoHuesped
        {
            get { return _fechaNacimientoHuesped; }
            set { _fechaNacimientoHuesped = value; }
        }
        public string ProcedenciaHuesped
        {
            get { return _procedenciaHuesped; }
            set { _procedenciaHuesped = value; }
        }
        public bool GeneroHuesped
        {
            get { return _generoHuesped; }
            set { _generoHuesped = value; }
        }

        //CREACIÓN DEL MÉTODO:
        public void Insertar_Huesped()
        {
            SqlConnection conexion;
            conexion = new SqlConnection("SERVER=PC-01\\SQLEXPRESS;DATABASE=Proyecto_Hotel;USER=sa;PWD=Y3553nia");
            SqlCommand comando;
            //No importa el orden
            comando = new SqlCommand("usp_Huesped_Insertar", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@parametroDniEmpleado", DocumentoIdentidadHuesped);
            comando.Parameters.AddWithValue("@parametroNombresEmpleado", NombresHuesped);
            comando.Parameters.AddWithValue("@parametroApellidosEmpleado", ApellidoPaternoHuesped);
            comando.Parameters.AddWithValue("@parametroDireccionEmpleado", ApellidoMaternoHuesped);
            comando.Parameters.AddWithValue("@parametroSueldoEmpleado", FechaNacimientoHuesped);
            comando.Parameters.AddWithValue("@parametroSexoEmpleado", ProcedenciaHuesped);
            comando.Parameters.AddWithValue("@parametroSexoEmpleado", GeneroHuesped);
            comando.Parameters.AddWithValue("@parametroidTurnoEmpleado", TurnoEmpleado.CodigoTurno);

            if (string.IsNullOrEmpty(IdRucH)) 
            {
                comando.Parameters.AddWithValue("@parametroTelefonoEmpleado", DBNull.Value);
            }
            else
            {
                comando.Parameters.AddWithValue("@parametroTelefonoEmpleado", IdRucH.IdRuc);
            }

            conexion.Open();
            comando.ExecuteReader();
            conexion.Close();
        }
    }
}
