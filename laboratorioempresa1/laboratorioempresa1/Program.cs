using System;
using System.IO;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace laboratorioempresa1
{
    class Program
    {
        static string inventario = "Inventario.txt";
        static string inventario2 = "Inventario nuevo.txt";

        static string facturacion = "Facturación.txt";

        static string usuariosa = "Usuariosadmin.txt";
        static string usuariost = "Usuariostrab.txt";

        static FileStream archivo;
        static StreamReader leer;
        static StreamWriter escribir;

       
        
        static int opcion = 0;


        static void lecturainv(string l)
        {
            string guardar = "";
            archivo = new FileStream(l, FileMode.Open, FileAccess.Read);
            leer = new StreamReader(inventario);
            guardar = leer.ReadToEnd();
            Console.WriteLine(guardar);
            leer.Close();

        }

        static void lecturainv2(string l)
        {
            string guardar = "";
            archivo = new FileStream(l, FileMode.Open, FileAccess.Read);
            leer = new StreamReader(inventario2);
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

        static void inicio()
        {
            escribir = File.AppendText(inventario);
            escribir.WriteLine("");
            escribir.Close();
        
            escribir = File.AppendText(usuariosa);
            escribir.WriteLine("");
            escribir.Close();
        
            escribir = File.AppendText(usuariost);
            escribir.WriteLine("");
            escribir.Close();
        
            escribir = File.AppendText(facturacion);
            escribir.WriteLine("");
            escribir.Close();
        }

        static void funcioninicial()
        {
            
            while (opcion != 3)
            {
                Console.WriteLine("\nEMPRESA LOS PATOS");
                Console.Write(" Seleccione \n  1. Administrador 2. Trabajador 3. Menú para salir   ");
                opcion = int.Parse(Console.ReadLine());
                if (opcion == 1)
                {
                    Console.Write("   Escriba su código: ");
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
                    Console.Write("   Escriba su código   ");
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
        }
        static void Main(string[] args)
        {   inicio();
            int salir = 0;
            while (salir != 1)
            {
                funcioninicial();

                Console.WriteLine("Salir  1. Si   2. No");
                salir = int.Parse(Console.ReadLine());
            }
            
            
        }


        static void menua()
        {

            Console.WriteLine("\n   Seleccione una opción:");
            Console.Write("   a. Inventario  b. Usuarios  c. Facturación  d.Menú de acceso   ");
            char area = char.Parse(Console.ReadLine());
            administrador(area);
        }


        static void administrador(char area)
        {

            if (area == 'a')
            {
                Console.WriteLine("   INVENTARIO");
                lecturainv(inventario);
                
                menua();
            }

            else if (area == 'b')
            {
                Console.Write("   Seleccione:\n   a.Crear usuario   b.Ver usuarios registrados   ");
                char op = char.Parse(Console.ReadLine());

                if (op == 'a')
                {
                    int t = 0;
                    while (t != 2)
                    {
                        Console.WriteLine("    Ingrese los siguientes datos:");
                        Console.Write("      Nombre  ");
                        string nombre = Console.ReadLine();
                        Console.Write("      Apellido  ");
                        string apellido = Console.ReadLine();
                        Console.Write("      Edad  ");
                        int edad = int.Parse(Console.ReadLine());
                        Console.Write("      Puesto de trabajo:   1. Administrador  2. Trabajador    ");
                        int puesto = int.Parse(Console.ReadLine());

                        if (puesto == 1)
                        {
                            string puestoa = Console.ReadLine();
                            puestoa = apellido + "admin";
                            Console.WriteLine("     Código de acceso: " + puestoa);
                            escribir = File.AppendText(usuariosa);
                            escribir.WriteLine(puestoa + '-' + apellido + '-' + nombre + '-' + edad);
                            Console.WriteLine("      Presione enter.");
                            escribir.Close();
                            Console.WriteLine("      Usuario creado.");
                            
                        }

                        else if (puesto == 2)
                        {
                            string puestot = Console.ReadLine();
                            puestot = apellido + "trab";
                            Console.WriteLine("     Código de acceso: " + puestot);
                            escribir = File.AppendText(usuariost);
                            escribir.WriteLine(puestot + '-' + apellido + '-' + nombre + '-' + edad);
                            escribir.Close();
                            Console.WriteLine("      Usuario creado.");
                            
                        }
                        
                        Console.Write("\n  Crear otro usuario  1. Si  2. No  ");
                        t = int.Parse(Console.ReadLine());
                    }

                    menua();
                }

                else if (op == 'b')
                {
                    Console.WriteLine("USUARIOS");
                    lecturaus(usuariosa);
                    lecturaus2(usuariost);
                    menua();
                }
            }
            else if (area == 'c')
            { Console.WriteLine("FACTURAS"); lecturafac(facturacion); menua(); }

            else if (area == 'd')
            { funcioninicial(); }


        }

        static void menut()
        {
            
            Console.WriteLine("\n     Seleccione una opción:");
            Console.Write("      a. Cargar inventario   b. Facturar productos   c.Menú de acceso   ");
            char area = char.Parse(Console.ReadLine());
            trabajador(area);    
        }

        static void trabajador(char area)
        {
            if (area == 'a')
            {
                int u = 0;
                while (u != 2)
                {
                    Console.WriteLine("      Escriba los siguientes datos:");
                    Console.Write("      Producto    ");
                    string producto = Console.ReadLine();
                    Console.Write("      Cantidad    ");
                    int cantidad = int.Parse(Console.ReadLine());
                    areainventario(producto, cantidad);
                    Console.Write("       Agregar otro producto 1. Si 2. No  ");
                    u = int.Parse(Console.ReadLine());
                }
                menut();
            }

            else if (area == 'b')
            {
                int u = 0;
                while(u != 2)
                { 
                Console.WriteLine("      Escriba los siguientes datos:");
                Console.Write("      Producto    ");
                string producto = Console.ReadLine();
                Console.Write("      Cantidad    ");
                int cantidad = int.Parse(Console.ReadLine());
                Console.Write("       Precio   ");
                int precio = int.Parse(Console.ReadLine());

               
                string p = "";
                leer = File.OpenText(inventario);
                p = leer.ReadLine();

                while (p != null)
                {
                    string[] vector = p.Split();
                    if (producto != vector[0])
                    {
                        Console.WriteLine("No existe");
                    }

                    else
                    {
                        escribir = File.AppendText(inventario2);
                        int c = int.Parse(vector[1]);
                        c = c - cantidad;
                        escribir.WriteLine("Dato actualizado:  " + vector[0] + '/' + c + '/' + vector[2]);

                        if (producto != vector[0])
                        {
                            escribir.WriteLine(vector[0] + '/' + vector[1] + '/' + vector[2]);
                        }

                        escribir.Close();

                        Console.Write("            Correlativo de factura:   ");
                        int cor = int.Parse(Console.ReadLine());
                        Console.Write("            Fecha:   ");
                        string fecha = Console.ReadLine();
                        Console.Write("            Nombre del Cliente:   ");
                        string cliente = Console.ReadLine();
                        Console.WriteLine("        Nit:   ");
                        string nit = Console.ReadLine();
                            string detalle = producto + " " + cantidad + " " + precio;
                            Console.WriteLine("            Detalle de la compra:    " + detalle);
                       
                        int total = cantidad * precio;
                        Console.WriteLine("            Monto total a pagar:   " + total);

                        escribir = File.AppendText(facturacion);
                        escribir.WriteLine("Correlativo de factura:  " + cor + "Fecha:  " + fecha);
                        escribir.WriteLine("Nombre del cliente:  " + cliente + "Nit:  " + nit);
                        escribir.WriteLine("Detalle de la compra:  " + detalle);
                        escribir.WriteLine("Monto total a pagar:  " + total);
                        escribir.Close();

                        Console.WriteLine("          ***Producto facturado***");
                    }
                    p = leer.ReadLine();
                }   
                leer.Close();

                Console.Write("       Agregar otra factura 1. Si 2. No  ");
                u = int.Parse(Console.ReadLine());
                }
                menut();

            }
            

            else if (area == 'c')
            {
                funcioninicial();
            }

        }


        static void areainventario(string producto, int cantidad)
        {
            string y = "";
            string p = "";
            leer = File.OpenText(inventario);
            p = leer.ReadLine();
            
            while(p!= null)
            {
                string[] vector = p.Split();
                if (producto != vector[0])
                {
                    y = "Agregado";
                }

                else
                {
                    
                    escribir = File.AppendText(inventario2);
                    int c = int.Parse(vector[1]);
                    c = c + cantidad;
                    escribir.WriteLine("Dato actualizado:  " + vector[0] + '/' + c + '/' + vector[2]);

                    if (producto != vector[0])
                    {
                        escribir.WriteLine(vector[0] + '/' + vector[1] + '/' + vector[2]);
                    }

                    escribir.Close();
                    
                    Console.WriteLine("          ***Producto actualizado***");
                }
                p = leer.ReadLine();   
            }
            leer.Close();

            if (y == "Agregado")
            {

                Console.Write("      Precio    ");
                double precio = double.Parse(Console.ReadLine());
                escribir = File.AppendText(inventario);
                escribir.WriteLine(producto + '/' + cantidad + '/' + precio);
                escribir.Close();
                Console.WriteLine("        ---Producto Agregado---");
            }

            else
            {
                File.Move(inventario, inventario2);
                File.Delete(inventario);
            }
        }
    }
}

    

