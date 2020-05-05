using System;
using System.IO;

namespace laboratorioempresa1
{
    class Program
    {
        static string inventario = "Inventario.txt";

        static string facturacion = "Facturación.txt";

        static string inventario2 = "Inventario.txt";

        static string facturacion2 = "Facturación.txt";

        static string usuariosa = "Usuariosadmin.txt";
        static string usuariost = "Usuariostrab.txt";

        static FileStream archivo;
        static StreamReader leer;
        static StreamWriter escribir;


        static int correlativo = 0;


        static void lecturainv(string l)
        {
            string guardar = "";
            archivo = new FileStream(l, FileMode.Open, FileAccess.Read);
            leer = new StreamReader(inventario);
            guardar = leer.ReadToEnd();
            Console.WriteLine(guardar);
            leer.Close();

        }

        static void lecturaus(string l)
        {
            string guardar = "";
            archivo = new FileStream(l, FileMode.Open, FileAccess.Read);
            leer = new StreamReader(usuariosa);
            guardar = leer.ReadToEnd();
            Console.WriteLine(guardar);
            leer.Close();

        }

        static void lecturaus2(string l)
        {
            string guardar = "";
            archivo = new FileStream(l, FileMode.Open, FileAccess.Read);
            leer = new StreamReader(usuariost);
            guardar = leer.ReadToEnd();
            Console.WriteLine(guardar);
            leer.Close();

        }

        static void lecturafac(string l)
        {
            string guardar = "";
            archivo = new FileStream(l, FileMode.Open, FileAccess.Read);
            leer = new StreamReader(facturacion);
            guardar = leer.ReadToEnd();
            Console.WriteLine(guardar);
            leer.Close();

        }

        static void inicioinv()
        {
            escribir = File.AppendText(inventario);
            escribir.WriteLine("INVENTARIO");
            escribir.Close();
        }

        static void inicious()
        {
            escribir = File.AppendText(usuariosa);
            escribir.WriteLine("USUARIOS ADMINISTRADOR");
            escribir.Close();
        }

        static void inicious2()
        {
            escribir = File.AppendText(usuariost);
            escribir.WriteLine("USUARIOS TRABAJADOR");
            escribir.Close();
        }

        static void iniciofac()
        {
            escribir = File.AppendText(facturacion);
            escribir.WriteLine("FACTURAS");
            escribir.Close();
        }

        static void funcioninicial()
        {
            Console.WriteLine("EMPRESA LOS PATOS");
            Console.WriteLine(" Seleccione el puesto que ocupa\n  1. Administrador 2. Trabajador");
            Console.Write("  ");
            int opcion = int.Parse(Console.ReadLine());
            if (opcion == 1)
            {
                Console.Write("Escriba su código: ");
                string cod = Console.ReadLine();
                if (cod == "admin")
                {
                    menua();
                }

                else
                {
                    string linea = "";
                    using (leer = new StreamReader(usuariosa))
                    {
                        while ((linea = leer.ReadLine()) != null)
                        {
                            string[] datos = linea.Split('-');
                            if (cod == datos[0])
                            { menua(); }
                        }

                        leer.Close();
                    }

                }
            }

            else if (opcion == 2)
            {
                Console.WriteLine("Escriba su código");
                string cod = Console.ReadLine();

                if (cod == "trab")
                { menut(); }
                else
                {
                    string linea = "";
                    using (leer = new StreamReader(usuariost))
                    {
                        while ((linea = leer.ReadLine()) != null)
                        {
                            string[] datos = linea.Split('-');
                            if (cod == datos[0])
                            {
                                menut();
                            }
                        }
                        leer.Close();
                    }
                }
            }




        }
        static void Main(string[] args)
        {
            inicioinv(); inicious(); iniciofac(); inicious2();
            char seleccion = 'b';
            while (seleccion == 'b')
            {
                funcioninicial();
                Console.Write("¿Desea salir?  a. Si  b. No   ");
                seleccion = char.Parse(Console.ReadLine());
            }


        }

        static void menua()
        {

            Console.WriteLine("\nEscriba la letra según el área a la que desea entrar");
            Console.WriteLine("a. Inventario\nb. Usuarios\nc. Facturación");
            Console.Write("  ");
            char area = char.Parse(Console.ReadLine());
            administrador(area);
        }


        static void administrador(char area)
        {

            if (area == 'a')
            {
                lecturainv(inventario);

            }

            else if (area == 'b')
            {
                Console.WriteLine("Seleccione una opción\na.Crear usuario   b.Ver usuarios registrados");
                char op = char.Parse(Console.ReadLine());

                if (op == 'a')
                {
                    Console.WriteLine("Ingrese los siguientes datos:");
                    Console.Write(" Nombre  ");
                    string nombre = Console.ReadLine();
                    Console.Write(" Apellido  ");
                    string apellido = Console.ReadLine();
                    Console.Write(" Edad  ");
                    int edad = int.Parse(Console.ReadLine());
                    Console.Write(" Puesto de trabajo:\n  1. Administrador\n  2. Trabajador");
                    int puesto = int.Parse(Console.ReadLine());

                    if (puesto == 1)
                    {
                        string puestoa = Console.ReadLine();
                        puestoa = apellido + "admin";
                        Console.WriteLine("Código de acceso: " + puestoa);
                        escribir = File.AppendText(usuariosa);
                        escribir.WriteLine(puestoa + '-' + apellido + '-' + nombre + '-' + edad);
                        escribir.Close();
                    }

                    else if (puesto == 2)
                    {
                        string puestot = Console.ReadLine();
                        puestot = apellido + "trab";
                        Console.WriteLine("Código de acceso: " + puestot);
                        escribir = File.AppendText(usuariost);
                        escribir.WriteLine(puestot + '-' + apellido + '-' + nombre + '-' + edad);
                        escribir.Close();
                    }
                    Console.WriteLine("Usuario creado.");
                }

                else if (op == 'b')
                {
                    lecturaus(usuariosa);
                    lecturaus2(usuariost);
                }
            }
            else if (area == 'c')
            { lecturafac(facturacion); }


        }

        static void menut()
        {
            Console.WriteLine("\nEscriba la letra según el área a la que desea entrar");
            Console.WriteLine("a. Cargar inventario\nb. Facturar productos");
            Console.Write("  ");
            char area = char.Parse(Console.ReadLine());
            trabajador(area);
        }
        static void trabajador(char area)
        {

            if (area == 'a')
            {
                Console.WriteLine("INVENTARIO\n Escriba los siguientes datos:");
                Console.Write("  Producto  ");
                string producto = Console.ReadLine();
                Console.Write("  Precio  ");
                double precio = double.Parse(Console.ReadLine());
                Console.Write("  Cantidad  ");
                string cantidad = Console.ReadLine();


            }

            else if (area == 'b')
            {
                correlativo++;
                Console.WriteLine("FACTURACION\n Escriba los siguientes datos:");
                Console.Write("  Nombre del cliente  ");
                string cliente = Console.ReadLine();
                Console.Write("  Nit  ");
                string nit = Console.ReadLine();
                Console.Write("  Fecha  ");
                string fecha = Console.ReadLine();
                Console.Write(" Producto comprado  ");
                string producto = Console.ReadLine();
                Console.Write("  Cantidad  ");
                int cantidad = int.Parse(Console.ReadLine());
                Console.Write(" Precio  ");
                double precio = double.Parse(Console.ReadLine());

                escribir = File.AppendText(facturacion);
                escribir.WriteLine(" Correlativo de factura  " + correlativo);
                escribir.WriteLine(" Nombre del Cliente  " + cliente);
                escribir.WriteLine(" Nit del Cliente  " + nit);
                escribir.WriteLine(" Fecha  " + fecha);
                escribir.WriteLine(" Detalle de compra  " + producto + " " + '-' + " " + precio + " " + '-' + " " + cantidad);
                escribir.WriteLine("Monto total a pagar   Q" + precio);
                escribir.Close();

            }


        }
    }
}

    

