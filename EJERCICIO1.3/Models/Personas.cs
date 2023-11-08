using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EJERCICIO1._3.Models {
    public class Personas {
        private List<string> invalidData = new List<string>();

        private string nombres;
        private string apellidos;
        private int edad;
        private string correo;
        private string direccion;





        public Personas() {
        }

        public Personas(string nombres, string apellidos, int edad, string correo, string direccion) {
            this.Nombres = nombres;
            this.Apellidos = apellidos;
            this.Edad = edad;
            this.Correo = correo;
            this.Direccion = direccion;
        }


        



        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }




        [Column("Nombres")]
        public string Nombres {
            get { return this.nombres; }

            set {
                string regExpPattern = "^[a-zA-Z' -]+$";

                if (!string.IsNullOrEmpty(value) && Regex.IsMatch(value, regExpPattern)) {
                    this.nombres = value;
                } else {
                    this.invalidData.Add("Nombres");
                }
            }
        }


        [Column("Apellidos")]
        public string Apellidos {
            get { return this.apellidos; }

            set {
                string regExpPattern = "^[a-zA-Z' -]+$";

                if (!string.IsNullOrEmpty(value) && Regex.IsMatch(value, regExpPattern)) {
                    this.apellidos = value;
                } else {
                    this.invalidData.Add("Apellidos");
                }
            }
        }



        [Column("Edad")]
        public int Edad{
            get { return this.edad; }

            set {
                if (value  > 0) {
                    this.edad = value;
                } else {
                    this.invalidData.Add("Edad");
                }
            }
        }




        [Column("Correo")]
        public string Correo{
            get { return this.correo; }

            set {
                string regExpPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";


                if (!string.IsNullOrEmpty(value) && Regex.IsMatch(value, regExpPattern)) {
                    this.correo = value;
                } else {
                    this.invalidData.Add("Correo");
                }
            }
        }


        [Indexed]
        [Column("Direccion")]
        public string Direccion {
            get { return this.direccion; }

            set {
                string regExpPattern = @"^[a-zA-Z0-9\s,.-]+$";

                if (!string.IsNullOrEmpty(value) && Regex.IsMatch(value, regExpPattern)) {
                    this.direccion = value;
                } else {
                    this.invalidData.Add("Direccion");
                }
            }
        }



        [Ignore]
        public string NombresApellidos {
            get { return this.nombres + " " + this.apellidos;}
        }


        public List<string> GetDatosInvalidos() {
            return this.invalidData;
        }

    }
}
