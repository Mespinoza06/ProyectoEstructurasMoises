using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.ConstrainedExecution;
using System.Security.Principal;
using System;
using System.Security.Cryptography;
using System.Threading.Channels;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Numerics;

class Pagos
{
    static int opcion = 0;
    static int op = 0;
    static int index = 10;
    static int[] numerodePago = new int[index];
    static DateTime[] Fecha = new DateTime[index];
    static TimeSpan[] Hora = new TimeSpan[index];
    static string[] nombre = new string[index];
    static string[] cedula = new string[index];
    static string[] apellido1 = new string[index];
    static string[] apellido2 = new string[index];
    static int[] numerodeCaja = new int[index];
    static int[] tipodeServicio = new int[index];
    static double[] numerofactura = new double[index];
    static double[] montoaPagar = new double[index];
    static double[] montocomisión = new double[index];
    static double[] montoDeducido = new double[index];
    static double[] montoPagaClient = new double[index];
    static double[] vuelto = new double[index];
    static double[] comision = new double[index];
    static string numeroComoCadena = "";
    static int opcionLimpia = 0;
    static int np = 1;
    static Random azar = new Random();
    static int factura = 1;
    static int electricidad = 0;
    static int telefono = 0;
    static int agua = 0;     
    static bool salir1 = false;
    static bool salir = false;
    static int contador = 0;
    static string valor = "";   
    static int consulta = 0;    
    static int modificar = 0;   
    static double acumuladora = 0;
    static int tipoServicio = 0;
    static int registro = 0;   
    static double acumuladora1 = 0;
    static double acumuladora2 = 0;
    static double acumuladora3 = 0;



    static void Main(string[] args)
    {
        do
        {
            try
            {
                while (true)
                {

                    Console.WriteLine("\nMenú Principal:");
                    Console.WriteLine("1. Inicializar Vectores");
                    Console.WriteLine("2. Realizar Pagos");
                    Console.WriteLine("3. Consultar Pagos");
                    Console.WriteLine("4. Modificar Pagos");
                    Console.WriteLine("5. Eliminar Pagos");
                    Console.WriteLine("6. Submenú Reportes");
                    Console.WriteLine("7. Salir");

                    Console.Write("Seleccione una opción: ");
                    opcion = int.Parse(Console.ReadLine());
                    string numeroComoCadena = opcion.ToString().TrimStart('0'); // convierte a string y Elimina los ceros a la izquierda
                    int opcionLimpio = int.Parse(numeroComoCadena);//regresa el string a entero


                    switch (opcionLimpio)
                    {
                        case 1:
                            inicializarVectores();
                            break;
                        case 2:
                            realizarPagos();
                            break;
                        case 3:
                            consultarPagos();
                            break;
                        case 4:
                            modificarPagos();
                            break;
                        case 5:
                            eliminarPagos();
                            break;
                        case 6:
                            submenuReportes();
                            break;
                        case 7:
                            Console.WriteLine("Saliendo del programa. ¡Hasta luego!");
                            return;
                        default:
                            Console.WriteLine("Opción inválida. Por favor, selecione un numero dentro del rango de menu.");

                            break;
                    }
                }

            }
            catch (Exception)
            {

                Console.WriteLine("Opcion inavalida, Solo se aceptan numeros");
            }






        } while (true);


    }//Se crea menu para poder acceder a las demas funciones
    static void inicializarVectores()
    {
        for (int i = 0; i < nombre.Length; i++)
        {
            numerodePago[i] = 0;
            Fecha[i] = DateTime.MinValue;
            Hora[i] = TimeSpan.Zero;
            nombre[i] = "";
            apellido1[i] = "";
            apellido2[i] = "";
            numerodeCaja[i] = 0;
            tipodeServicio[i] = 0;
            numerofactura[i] = 0;
            montoaPagar[i] = 0;
            montocomisión[i] = 0;
            montoDeducido[i] = 0;
            montoPagaClient[i] = 0;
            vuelto[i] = 0;
        }
        Console.WriteLine("Los vectores se inicializaron con exito");
    }//Se incializan los vectores
    static void realizarPagos()
    {
        do
        {
            if (contador < index)
            {

                numerodePago[contador] = contador + 1;
                Fecha[contador] = DateTime.Now;
                Hora[contador] = DateTime.Now.TimeOfDay;


                Console.WriteLine("Digite el numero de cedula");
                cedula[contador] = Console.ReadLine().Trim();

                Console.WriteLine($"Digite el Nombre del cliente {contador + 1}");
                nombre[contador] = Console.ReadLine();

                Console.WriteLine($"Digite el primer Apellido {contador + 1}");
                apellido1[contador] = Console.ReadLine();

                Console.WriteLine($"Digite el segundo apellido {contador + 1}");
                apellido2[contador] = Console.ReadLine();
                //un numero random de 1 a 3
                numerodeCaja[contador] = azar.Next(1,4);
                Console.WriteLine("EL NUMERO DE CAJA ES :" + numerodeCaja[contador]);


                bool salir2 = true;
                //selecciona el tipo de servicio y asigna l3 % de comision
                do
                {

                    try
                    {
                        salir2 = true;
                        Console.WriteLine("Digite el tipo de servicio (1= Recibo de Luz 2= Recibo Teléfono 3= Recibo de Agua).");
                        tipodeServicio[contador] = int.Parse(Console.ReadLine());

                        switch (tipodeServicio[contador])
                        {
                            case 1:
                                comision[contador] = 0.04;
                                
                                break;
                            case 2:
                                comision[contador] = 0.055;
                                
                                break;
                            case 3:
                                comision[contador] = 0.065;
                                
                                break;
                            default:
                                Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                                salir2 = false;
                                continue;

                        }





                    }
                    catch (Exception)
                    {

                        Console.WriteLine("Error de formato");
                        salir2 = false;
                    }
                } while (!salir2);








                do
                {
                    salir1 = true;
                    try
                    {
                        Console.WriteLine("Digite el monto a pagar");
                        montoaPagar[contador] = double.Parse(Console.ReadLine());

                        Console.WriteLine("Digite el monto con el que va a pagar");
                        montoPagaClient[contador] = double.Parse(Console.ReadLine());

                        //verifica si el monto que cancela el cliente es mayor al del pago
                        if (montoPagaClient[contador] >= montoaPagar[contador])
                        {
                            Console.WriteLine("El pago se realiza con éxito");
                            vuelto[contador] = montoPagaClient[contador] - montoaPagar[contador];

                        }
                        else
                        {
                            Console.WriteLine("Imposible de realizar el pago, intente de nuevo");
                            salir1 = false;
                        }


                    }
                    catch (Exception)
                    {

                        Console.WriteLine("Error de formato, intente de nuevo");
                        salir1 = false;
                    }

                } while (!salir1);


                numerofactura[contador] = azar.Next(10001);
                montocomisión[contador] = montoaPagar[contador] * comision[contador];
                montoDeducido[contador] = montoaPagar[contador] - montocomisión[contador];
                vuelto[contador] = montoPagaClient[contador] - montoaPagar[contador];
               
                Console.WriteLine($"PAGO REALIZADO CON EXITO");




                contador++;



            }
            else
            {
                Console.WriteLine("Los vectores estan llenos");

            }

            do
            {
                Console.WriteLine("Desea Realizar otro pago (S/N)");
                valor = Console.ReadLine().ToUpper();

                if (valor == "S")
                {
                    salir = false;
                    salir1 = true;


                }
                else if (valor == "N")
                {
                    salir = true;
                    salir1 = true;

                }
                else
                {
                    Console.WriteLine("Digite la opcion que se le solicita");
                    salir1 = false;
                }

            } while (!salir1);







        } while (!salir);


    }// se comienzan a lleanr los vectores
    static void consultarPagos()
    {
        do
        {
            bool encontrada = false;
            do
            {
                try
                {
                    Console.WriteLine("Digite el numero de Pago a consultar");
                    consulta = int.Parse(Console.ReadLine());

                    encontrada = false;
                }
                catch (Exception)
                {

                    Console.WriteLine("error de formato intente de nuevo");
                    encontrada = true;
                }

            } while (encontrada);
            //compara consulta con o que hay en el vector
            bool pagoEncontrado = false;//se usa para entre al if si no encuentra un pago
            for (int i = 0; i < nombre.Length; i++)
            {
                if (consulta == numerodePago[i])
                {
                    pagoEncontrado = true;
                    Console.Clear();
                    Console.WriteLine("__________________________________________________________________________");
                    Console.WriteLine("__________________________________________________________________________");
                    Console.WriteLine("                 Sistema Pagos De Servicios publicos                     ");
                    Console.WriteLine("                 Tienda La Favorita-Consulta de Datos                    ");
                    Console.WriteLine("                                                                         ");
                    Console.WriteLine($"Numero de Pago:      {numerodePago[i]}                                               ");
                    Console.WriteLine($"Fecha:               {Fecha[i].ToShortDateString()}      Hora:      {Hora[i]}        ");
                    Console.WriteLine("                                                                                      ");
                    Console.WriteLine($"Cedula:              {cedula[i]}      Nombre:              {nombre[i]}               ");
                    Console.WriteLine($"Apellido1:           {apellido1[i]}      Apellido2:           {apellido2[i]}         ");
                    Console.WriteLine("                                                                                      ");
                    Console.WriteLine($"Tipo de servicio:    {tipodeServicio[i]}      [1.Electricidad,2.Telefeno,3.Agua]     ");
                    Console.WriteLine("                                                                                      ");
                    Console.WriteLine($"Numero de Factura:   {numerofactura[i]}      Monto a pagar:   {montoaPagar[i]}       ");
                    Console.WriteLine($"Comision autorizada: {montocomisión[i]}      Paga con:        {montoPagaClient[i]}   ");
                    Console.WriteLine($"Monto deducido:      {montoDeducido[i]}      vuelto:          {vuelto[i]}            ");
                    Console.WriteLine("__________________________________________________________________________");
                    break;
                }
            }

            if (!pagoEncontrado)
            {
                Console.Clear();
                Console.WriteLine("__________________________________________________________________________");
                Console.WriteLine("__________________________________________________________________________");
                Console.WriteLine("                 Sistema Pagos De Servicios publicos                     ");
                Console.WriteLine("                 Tienda La Favorita-Consulta de Datos                    ");
                Console.WriteLine("                                                                         ");
                Console.WriteLine($"                 PAGO NO SE ENCUENTRA REGISTRADO                         ");
                Console.WriteLine("                                                                          ");
                Console.WriteLine("__________________________________________________________________________");
                Console.WriteLine("__________________________________________________________________________");
            }

            Console.WriteLine("Desea Realizar otra Consulta (S/N)");
            valor = Console.ReadLine().ToUpper();

            if (valor == "S")
            {
                salir1 = false;
            }
            else if (valor == "N")
            {
                salir1 = true;
            }
            else
            {
                Console.WriteLine("intente de nuevo");
            }
        } while (!salir1);



    }
    static void modificarPagos()
    {

        do
        {
            bool encontrada = false;
            do
            {
                try
                {
                    Console.WriteLine("Digite el numero de Pago a consultar");
                    consulta = int.Parse(Console.ReadLine());

                    encontrada = false;
                }
                catch (Exception)
                {

                    Console.WriteLine("error de formato intente de nuevo");
                    encontrada = true;
                }

            } while (encontrada);

            bool pagoEncontrado = false;
            for (int i = 0; i < nombre.Length; i++)
            {
                //muestra lo que encuentra y da las opciones del menu modificar
                if (consulta == numerodePago[i])
                {
                    pagoEncontrado = true;
                    Console.Clear();
                    Console.WriteLine("__________________________________________________________________________");
                    Console.WriteLine("__________________________________________________________________________");
                    Console.WriteLine("                 Sistema Pagos De Servicios publicos                     ");
                    Console.WriteLine("                 Tienda La Favorita-Consulta de Datos                    ");
                    Console.WriteLine("                                                                         ");
                    Console.WriteLine($"Numero de Pago:      {numerodePago[i]}                                               ");
                    Console.WriteLine($"Fecha:               {Fecha[i].ToShortDateString()}      Hora:      {Hora[i]}        ");
                    Console.WriteLine("                                                                                      ");
                    Console.WriteLine($"Cedula:              {cedula[i]}      Nombre:              {nombre[i]}               ");
                    Console.WriteLine($"Apellido1:           {apellido1[i]}      Apellido2:           {apellido2[i]}         ");
                    Console.WriteLine("                                                                                      ");
                    Console.WriteLine($"Tipo de servicio:    {tipodeServicio[i]}      [1.Electricidad,2.Telefeno,3.Agua]     ");
                    Console.WriteLine("                                                                                      ");
                    Console.WriteLine($"Numero de Factura:   {numerofactura[i]}      Monto a pagar:   {montoaPagar[i]}       ");
                    Console.WriteLine($"Comision autorizada: {montocomisión[i]}      Paga con:        {montoPagaClient[i]}   ");
                    Console.WriteLine($"Monto deducido:      {montoDeducido[i]}      vuelto:          {vuelto[i]}            ");
                    Console.WriteLine("__________________________________________________________________________");


                    Console.WriteLine("*** Que desea Modificar ***");
                    Console.WriteLine("Modificar 1-Numero de Pago");
                    Console.WriteLine("Modificar 2-Fecha");
                    Console.WriteLine("Modificar 3-Hora");
                    Console.WriteLine("Modificar 4-Cedula");
                    Console.WriteLine("Modificar 5.Nombre");
                    Console.WriteLine("Modificar 6-Apellido1");
                    Console.WriteLine("Modificar 7-Apellido2");
                    Console.WriteLine("Modificar 8-Numero de Caja");
                    Console.WriteLine("Modificar 9-Tipo de Servicio");
                    Console.WriteLine("Modificar 10-Numero de Factura ");
                    Console.WriteLine("Modificar 11-Monto a Pagar");
                    Console.WriteLine("Modificar 12-Monto que paga el Cliente ");


                    do
                    {
                        salir = true;
                        try
                        {
                            modificar = int.Parse(Console.ReadLine());
                        }
                        catch (Exception)
                        {

                            Console.WriteLine("Error de formato");
                            salir = false;
                        }

                    } while (!salir);


                    //se usa para selecionar modificar cada vector
                    switch (modificar)
                    {
                        case 1:
                            do
                            {
                                salir = true;
                                try
                                {
                                    Console.WriteLine("Digite el nuevo numero de pago");
                                    numerodePago[i] = int.Parse(Console.ReadLine());
                                }
                                catch (Exception)
                                {

                                    Console.WriteLine("Error de formato");
                                    salir = false;
                                }

                            } while (!salir);


                            break;

                        case 2:

                            do
                            {
                                Console.WriteLine("Ingrese la fecha en formato Dia/Mes/Año:");
                                string fechaNueva = Console.ReadLine();

                                try
                                {

                                    DateTime fecha = DateTime.ParseExact(fechaNueva, "dd/MM/yyyy", CultureInfo.InvariantCulture);//cultere se utiliza para interpretar el formato

                                    Fecha[i] = fecha;
                                    break;
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Formato de fecha inválido. Por favor, ingrese la fecha en el formato correcto (dd/mm/aaaa).");
                                }

                            } while (true);

                            break;//fecha

                        case 3:

                            do
                            {


                                try
                                {
                                    Console.WriteLine("Ingrese las nuevas horas:");
                                    int nuevasHoras = int.Parse(Console.ReadLine());


                                    Console.WriteLine("Ingrese los nuevos minutos:");
                                    int nuevosMinutos = int.Parse(Console.ReadLine());

                                    // Crear un nuevo TimeSpan con las horas y minutos actualizados
                                    Hora[i] = new TimeSpan(nuevasHoras, nuevosMinutos, 0);
                                    break;
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Formato de hora inválido. Por favor, ingrese la hora en el formato correcto (HH:mm:ss).");
                                }
                            } while (true);
                            break;//hora

                        case 4:
                            Console.WriteLine("Digite el numero de cedula");
                            cedula[i] = Console.ReadLine().Trim();


                            break;//cedula

                        case 5:
                            Console.WriteLine($"Digite el Nombre del cliente {contador + 1}");
                            nombre[i] = Console.ReadLine();


                            break;//nombre

                        case 6:
                            Console.WriteLine($"Digite el primer Apellido {contador + 1}");
                            apellido1[i] = Console.ReadLine();

                            break;//apellido

                        case 7:

                            Console.WriteLine($"Digite el segundo Apellido {contador + 1}");
                            apellido2[i] = Console.ReadLine();

                            break;//apellido2

                        case 8:
                            numerodeCaja[i] = azar.Next(1,4);
                            Console.WriteLine("Numero de caja modificado");

                            break;//numero de caja

                        case 9:


                            bool salir2 = true;

                            do
                            {

                                try
                                {
                                    salir2 = true;
                                    Console.WriteLine("Digite el tipo de servicio (1= Recibo de Luz 2= Recibo Teléfono 3= Recibo de Agua).");
                                    tipodeServicio[i] = int.Parse(Console.ReadLine());

                                    switch (tipodeServicio[i])
                                    {
                                        case 1:
                                            comision[i] = 0.04;

                                            break;
                                        case 2:
                                            comision[i] = 0.055;
                                            break;
                                        case 3:
                                            comision[i] = 0.065;
                                            break;
                                        default:
                                            Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                                            salir2 = false;
                                            continue;

                                    }



                                }
                                catch (Exception)
                                {

                                    Console.WriteLine("Error de formato");
                                    salir2 = false;
                                }
                            } while (!salir2);

                            break;//tipo servicio

                        case 10:
                            numerofactura[i] = azar.Next(10001);
                            Console.WriteLine("Numero de factura modificado");
                            break;//numero factura

                        case 11://monto a pagar
                            do
                            {
                                salir1 = true;
                                try
                                {
                                    Console.WriteLine("Digite el monto a pagar");
                                    montoaPagar[i] = double.Parse(Console.ReadLine());

                                }
                                catch (Exception)
                                {

                                    Console.WriteLine("Error de formato, intente de nuevo");
                                    salir1 = false;
                                }

                            } while (!salir1);
                            break;//monto a pagar

                        case 12:
                            do
                            {
                                salir1 = true;
                                try
                                {
                                    Console.WriteLine("Digite el monto con el que va a pagar");
                                    montoPagaClient[i] = double.Parse(Console.ReadLine());


                                    if (montoPagaClient[i] >= montoaPagar[i])
                                    {
                                        Console.WriteLine("El pago se realiza con éxito");
                                        vuelto[i] = montoPagaClient[i] - montoaPagar[i];

                                    }
                                    else
                                    {
                                        Console.WriteLine("Imposible de realizar el pago, intente de nuevo");
                                        salir1 = false;
                                    }


                                }
                                catch (Exception)
                                {

                                    Console.WriteLine("Error de formato, intente de nuevo");
                                    salir1 = false;
                                }

                            } while (!salir1);
                            break;//monto paga cliente

                        default:
                            Console.WriteLine("Digite un rango de 1 a 12");
                            continue;
                    }

                    montocomisión[i] = montoaPagar[i] * comision[i];
                    montoDeducido[i] = montoaPagar[i] - montocomisión[i];
                    vuelto[i] = montoPagaClient[i] - montoaPagar[i];
                }


            }

            if (!pagoEncontrado)
            {
                Console.Clear();
                Console.WriteLine("__________________________________________________________________________");
                Console.WriteLine("__________________________________________________________________________");
                Console.WriteLine("                 Sistema Pagos De Servicios publicos                     ");
                Console.WriteLine("                 Tienda La Favorita-Consulta de Datos                    ");
                Console.WriteLine("                                                                         ");
                Console.WriteLine($"                 PAGO NO SE ENCUENTRA REGISTRADO                         ");
                Console.WriteLine("                                                                          ");
                Console.WriteLine("__________________________________________________________________________");
                Console.WriteLine("__________________________________________________________________________");
            }

            Console.WriteLine("Desea Realizar otra Modificacion (S/N)");
            valor = Console.ReadLine().ToUpper();

            if (valor == "S")
            {
                salir1 = false;
            }
            else if (valor == "N")
            {
                salir1 = true;
            }
            else
            {
                Console.WriteLine("intente de nuevo");
            }
        } while (!salir1);

    }
    static void eliminarPagos()
    {
        do
        {
            bool encontrada = false;
            do
            {
                try
                {
                    Console.WriteLine("Digite el numero de Pago a consultar");
                    consulta = int.Parse(Console.ReadLine());

                    encontrada = false;
                }
                catch (Exception)
                {

                    Console.WriteLine("error de formato intente de nuevo");
                    encontrada = true;
                }

            } while (encontrada);

            bool pagoEncontrado = false;
            for (int i = 0; i < nombre.Length; i++)
            {
                if (consulta == numerodePago[i])
                {
                    pagoEncontrado = true;
                    Console.Clear();
                    Console.WriteLine("__________________________________________________________________________");
                    Console.WriteLine("__________________________________________________________________________");
                    Console.WriteLine("                 Sistema Pagos De Servicios publicos                     ");
                    Console.WriteLine("                 Tienda La Favorita-Consulta de Datos                    ");
                    Console.WriteLine("                                                                         ");
                    Console.WriteLine($"Numero de Pago:      {numerodePago[i]}                                               ");
                    Console.WriteLine($"Fecha:               {Fecha[i].ToShortDateString()}      Hora:      {Hora[i]}        ");
                    Console.WriteLine("                                                                                      ");
                    Console.WriteLine($"Cedula:              {cedula[i]}      Nombre:              {nombre[i]}               ");
                    Console.WriteLine($"Apellido1:           {apellido1[i]}      Apellido2:           {apellido2[i]}         ");
                    Console.WriteLine("                                                                                      ");
                    Console.WriteLine($"Tipo de servicio:    {tipodeServicio[i]}      [1.Electricidad,2.Telefeno,3.Agua]     ");
                    Console.WriteLine("                                                                                      ");
                    Console.WriteLine($"Numero de Factura:   {numerofactura[i]}      Monto a pagar:   {montoaPagar[i]}       ");
                    Console.WriteLine($"Comision autorizada: {montocomisión[i]}      Paga con:        {montoPagaClient[i]}   ");
                    Console.WriteLine($"Monto deducido:      {montoDeducido[i]}      vuelto:          {vuelto[i]}            ");
                    Console.WriteLine("__________________________________________________________________________");
                    Console.WriteLine("__________________________________________________________________________");
                    Console.WriteLine("                                                                            ");

                    do
                    {
                        Console.WriteLine("¿Está seguro de eliminar el dato? (S/N)");
                        string respuesta = Console.ReadLine().ToUpper();
                        if (respuesta == "S")
                        {
                            // Eliminar el dato

                            numerodePago[i] = 0;
                            Fecha[i] = DateTime.MinValue;
                            Hora[i] = TimeSpan.Zero;
                            nombre[i] = "";
                            apellido1[i] = "";
                            apellido2[i] = "";
                            numerodeCaja[i] = 0;
                            tipodeServicio[i] = 0;
                            numerofactura[i] = 0;
                            montoaPagar[i] = 0;
                            montocomisión[i] = 0;
                            montoDeducido[i] = 0;
                            montoPagaClient[i] = 0;
                            vuelto[i] = 0; // Marcar el número de pago como 0 para indicar que está vacío
                            Console.WriteLine("La información ya fue eliminada");
                            break;
                        }
                        else if (respuesta == "N")
                        {
                            Console.WriteLine("La información no fue eliminada");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Solo se acepta S O N");
                        }

                    } while (true);
                   
                    break;
                }
                Console.WriteLine("");
            }

            if (!pagoEncontrado)
            {
                Console.Clear();
                Console.WriteLine("__________________________________________________________________________");
                Console.WriteLine("__________________________________________________________________________");
                Console.WriteLine("                 Sistema Pagos De Servicios publicos                     ");
                Console.WriteLine("                 Tienda La Favorita-Consulta de Datos                    ");
                Console.WriteLine("                                                                         ");
                Console.WriteLine($"                 PAGO NO SE ENCUENTRA REGISTRADO                         ");
                Console.WriteLine("                                                                          ");
                Console.WriteLine("__________________________________________________________________________");
                Console.WriteLine("__________________________________________________________________________");
            }

            Console.WriteLine("Desea Eliminar otro pago (S/N)");
            valor = Console.ReadLine().ToUpper();

            if (valor == "S")
            {
                salir1 = false;
            }
            else if (valor == "N")
            {
                salir1 = true;
            }
            else
            {
                Console.WriteLine("intente de nuevo");
            }
        } while (!salir1);

    }
    static void submenuReportes()
    {
        int opcion = 0;
        bool opcionValida = false;

        do
        {
            // Mostrar el menú de reportes
            Console.WriteLine("Submenú Reportes");
            Console.WriteLine("1. Ver todos los Pagos");
            Console.WriteLine("2. Ver Pagos por tipo de Servicio");
            Console.WriteLine("3. Ver Pagos por código de caja");
            Console.WriteLine("4. Ver Dinero Comisionado por servicios");
            Console.WriteLine("5. Regresar Menú Principal");
            Console.WriteLine("Ingrese su opción:");

            // Leer la opción del usuario
            try
            {
                opcion = int.Parse(Console.ReadLine());
                opcionValida = true;
                
            }
            catch (FormatException)
            {
                Console.WriteLine("Opción inválida. Por favor, ingrese un número válido.");
            }

            // Ejecutar la opción seleccionada
            switch (opcion)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("                 Sistema Pagos De Servicios publicos                     ");
                    Console.WriteLine("                 Tienda La Favorita-Consulta de Datos                    ");
                    Console.WriteLine("                                                                         ");
                    Console.WriteLine("#Pago    Fecha/HoraPago            Cedula      Nombre    Apellido1    Apellido2     Monto Recibido  ");
                    Console.WriteLine("=========================================================================");
                    for (int i = 0; i < nombre.Length; i++)
                    {




                        Console.WriteLine(numerodePago[i] + "    " + Fecha[i].ToShortDateString() + "  " + Hora[i] + "   " + cedula[i] + "    " + nombre[i] + "   " + apellido1[i] + "   " + apellido2[i] + "       " + montoaPagar[i]);
                        acumuladora = montoaPagar[i] + acumuladora;
                        
                        
                        


                    }
                    Console.WriteLine("=========================================================================");
                    Console.WriteLine("Total de registros " + numerodePago[contador] + "                                                     Monto Tota:" + acumuladora);


                    break;

                case 2:
                   
                    bool continuarConsulta = true;
                    do
                    {

                        do
                        {
                            try
                            {
                                Console.WriteLine("Digite el tipo de servicio a consultar");
                                Console.WriteLine(" 1. Electricidad  2.Telefono 3.Agua");
                                tipoServicio = int.Parse(Console.ReadLine());
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Opción inválida. Por favor, ingrese un número válido.");
                            }

                        } while (true);

                        switch (tipoServicio)
                        {
                            case 1:
                                Console.Clear();

                                Console.WriteLine("                 Sistema Pagos De Servicios publicos                     ");
                                Console.WriteLine("                 Tienda La Favorita-Consulta de Datos                    ");
                                Console.WriteLine("                                                                         ");
                                Console.WriteLine("#Pago    Fecha/HoraPago            Cedula      Nombre    Apellido1    Apellido2     Monto Recibido  ");
                                Console.WriteLine("=========================================================================");
                                salir1 = false;
                                for (int i = 0; i < nombre.Length; i++)
                                {




                                    if (tipoServicio == tipodeServicio[i])
                                    {


                                        Console.WriteLine(numerodePago[i] + "    " + Fecha[i].ToShortDateString() + "  " + Hora[i] + "   " + cedula[i] + "    " + nombre[i] + "   " + apellido1[i] + "   " + apellido2[i] + "       " + montoaPagar[i]);
                                        acumuladora = montoaPagar[i] + acumuladora;
                                        registro = registro + 1;
                                        salir1 = true;
                                    }
                                  


                                }

                                if (!salir1)
                                {
                                                                     
                                   Console.WriteLine("No Tiene servicios de Telefono Registrados");
                                   
                                }
                                Console.WriteLine("=========================================================================");
                                Console.WriteLine("Total de registros " + registro + "                                                     Monto Tota:" + acumuladora);
                                break;

                            case 2:
                                registro = 0;
                                acumuladora = 0;
                                Console.Clear();

                                Console.WriteLine("                 Sistema Pagos De Servicios publicos                     ");
                                Console.WriteLine("                 Tienda La Favorita-Consulta de Datos                    ");
                                Console.WriteLine("                                                                         ");
                                Console.WriteLine("#Pago    Fecha/HoraPago            Cedula      Nombre    Apellido1    Apellido2     Monto Recibido  ");
                                Console.WriteLine("=========================================================================");
                                salir1 = false;
                                for (int i = 0; i < nombre.Length; i++)
                                {




                                    if (tipoServicio == tipodeServicio[i])
                                    {


                                        Console.WriteLine(numerodePago[i] + "    " + Fecha[i].ToShortDateString() + "  " + Hora[i] + "   " + cedula[i] + "    " + nombre[i] + "   " + apellido1[i] + "   " + apellido2[i] + "       " + montoaPagar[i]);
                                        acumuladora = montoaPagar[i] + acumuladora;
                                        registro = registro + 1; ;
                                        salir1 = true;
                                    }
                                  


                                }
                                if (!salir1)
                                {

                                    Console.WriteLine("No Tiene servicios de Telefono Registrados");

                                }
                                Console.WriteLine("=========================================================================");
                                Console.WriteLine("Total de registros " + registro + "                                                     Monto Tota:" + acumuladora);
                                break;

                            case 3:
                                registro = 0;
                                acumuladora = 0;
                                Console.Clear();

                                Console.WriteLine("                 Sistema Pagos De Servicios publicos                     ");
                                Console.WriteLine("                 Tienda La Favorita-Consulta de Datos                    ");
                                Console.WriteLine("                                                                         ");
                                Console.WriteLine("#Pago    Fecha/HoraPago            Cedula      Nombre    Apellido1    Apellido2     Monto Recibido  ");
                                Console.WriteLine("=========================================================================");
                                salir1 = false;
                                for (int i = 0; i < nombre.Length; i++)
                                {




                                    if (tipoServicio == tipodeServicio[i])
                                    {


                                        Console.WriteLine(numerodePago[i] + "    " + Fecha[i].ToShortDateString() + "  " + Hora[i] + "   " + cedula[i] + "    " + nombre[i] + "   " + apellido1[i] + "   " + apellido2[i] + "       " + montoaPagar[i]);
                                        acumuladora = montoaPagar[i] + acumuladora;
                                        registro = registro + 1;
                                        salir1 = true;
                                    }
                                    


                                }
                                if (!salir1)
                                {

                                    Console.WriteLine("No Tiene servicios de Telefono Registrados");

                                }
                                Console.WriteLine("=========================================================================");
                                Console.WriteLine("Total de registros " + registro + "                                                     Monto Tota:" + acumuladora);
                                break;

                               
                            default:
                                Console.WriteLine("Opcion incorrecta");
                                continue;
                                
                        }

                        Console.WriteLine("¿Desea realizar otra consulta? (S/N)");
                        string respuesta = Console.ReadLine();

                        if (respuesta.ToUpper() == "S")
                        {
                            continuarConsulta = true;
                        }
                        else if (respuesta.ToUpper()=="N")
                        {
                            continuarConsulta = false;
                        }
                        else
                        {
                            Console.WriteLine("intente de nuevo");
                        }
                        


                    } while (continuarConsulta);
                    break;

                case 3:                   

                    
                    continuarConsulta = true;
                    do
                    {

                        do
                        {
                            try
                            {
                                Console.WriteLine("Digite el tipo de servicio a consultar");
                                Console.WriteLine(" 1. Caja[1]  2.Caja[2] 3.Caja[3]");
                                tipoServicio = int.Parse(Console.ReadLine());
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Opción inválida. Por favor, ingrese un número válido.");
                            }

                        } while (true);

                        switch (tipoServicio)
                        {
                            case 1:
                                Console.Clear();

                                Console.WriteLine("                 Sistema Pagos De Servicios publicos                     ");
                                Console.WriteLine("                 Tienda La Favorita-Consulta de Datos                    ");
                                Console.WriteLine("                                                                         ");
                                Console.WriteLine("#Pago    Fecha/HoraPago            Cedula      Nombre    Apellido1    Apellido2     Monto Recibido  ");
                                Console.WriteLine("=========================================================================");
                                salir1 = false;
                                for (int i = 0; i < nombre.Length; i++)
                                {




                                    if (numerodeCaja[i]==1)
                                    {


                                        Console.WriteLine(numerodePago[i] + "    " + Fecha[i].ToShortDateString() + "  " + Hora[i] + "   " + cedula[i] + "    " + nombre[i] + "   " + apellido1[i] + "   " + apellido2[i] + "       " + montoaPagar[i]);
                                        acumuladora = montoaPagar[i] + acumuladora;
                                        registro = registro + 1;
                                        salir1 = true;
                                    }
                                   



                                }
                                  if (!salir1)
                                {

                                    Console.WriteLine("No Tiene pagos registrados en Caja[1]");

                                }
                                Console.WriteLine("=========================================================================");
                                Console.WriteLine("Total de registros " + registro + "                                                     Monto Tota:" + acumuladora);
                                break;

                            case 2:
                                registro = 0;
                                acumuladora = 0;
                                Console.Clear();

                                Console.WriteLine("                 Sistema Pagos De Servicios publicos                     ");
                                Console.WriteLine("                 Tienda La Favorita-Consulta de Datos                    ");
                                Console.WriteLine("                                                                         ");
                                Console.WriteLine("#Pago    Fecha/HoraPago            Cedula      Nombre    Apellido1    Apellido2     Monto Recibido  ");
                                Console.WriteLine("=========================================================================");
                                salir1 = false;
                                for (int i = 0; i < nombre.Length; i++)
                                {




                                    if (numerodeCaja[i]==2)
                                    {


                                        Console.WriteLine(numerodePago[i] + "    " + Fecha[i].ToShortDateString() + "  " + Hora[i] + "   " + cedula[i] + "    " + nombre[i] + "   " + apellido1[i] + "   " + apellido2[i] + "       " + montoaPagar[i]);
                                        acumuladora = montoaPagar[i] + acumuladora;
                                        registro = registro + 1;
                                        salir1 = true;
                                    }
                                  


                                }
                                                                                    
                                if (!salir1)
                                { 

                                    Console.WriteLine("No Tiene Pagos Registrados en Caja[2]");
                                                                   


                                }
                                Console.WriteLine("=========================================================================");
                                Console.WriteLine("Total de registros " + registro + "                                                     Monto Tota:" + acumuladora);
                                break;

                            case 3:
                                registro = 0;
                                acumuladora = 0;
                                

                                Console.WriteLine("                 Sistema Pagos De Servicios publicos                     ");
                                Console.WriteLine("                 Tienda La Favorita-Consulta de Datos                    ");
                                Console.WriteLine("                                                                         ");
                                Console.WriteLine("#Pago    Fecha/HoraPago            Cedula      Nombre    Apellido1    Apellido2     Monto Recibido  ");
                                Console.WriteLine("=========================================================================");
                                salir1 = false;
                                for (int i = 0; i < nombre.Length; i++)
                                {




                                    if (numerodeCaja[i]==3)
                                    {


                                        Console.WriteLine(numerodePago[i] + "    " + Fecha[i].ToShortDateString() + "  " + Hora[i] + "   " + cedula[i] + "    " + nombre[i] + "   " + apellido1[i] + "   " + apellido2[i] + "       " + montoaPagar[i]);
                                        acumuladora = montoaPagar[i] + acumuladora;
                                        registro = registro + 1;
                                        salir1 = true;
                                    }
                                   



                                }
                               
                                if (!salir1)
                                {

                                    Console.WriteLine("No Tiene Pagos Registrados en Caja[3]");

                                }

                                Console.WriteLine("=========================================================================");
                                Console.WriteLine("Total de registros " + registro + "                                                     Monto Tota:" + acumuladora);
                                break;


                            default:
                                Console.WriteLine("Opcion incorrecta");
                                continue;

                        }

                        Console.WriteLine("¿Desea realizar otra consulta? (S/N)");
                        string respuesta = Console.ReadLine();

                        if (respuesta.ToUpper() == "S")
                        {
                            continuarConsulta = true;
                        }
                        else if (respuesta.ToUpper() == "N")
                        {
                            continuarConsulta = false;
                        }
                        else
                        {
                            Console.WriteLine("intente de nuevo");
                        }



                    } while (continuarConsulta);


                    break;
                case 4:
                    electricidad = 0;
                    telefono = 0;
                    agua = 0;
                    acumuladora1 = 0;
                    acumuladora2 =0;
                    acumuladora3 = 0;

                    Console.Clear();
                    Console.WriteLine("Reporte Dinero Comisionado-Desgloce por tipo de Servicio");
                    Console.WriteLine("========================================================");
                    Console.WriteLine("Item           Cant.Transacciones            Total Comisionado");
                    continuarConsulta = true;
                    for (int i = 0; i < nombre.Length; i++)
                    {
                        

                        if (tipodeServicio[i]==1)
                        {
                            electricidad = electricidad + 1;
                            acumuladora1 = montocomisión[i] + acumuladora1;
                            continuarConsulta = false;
                        }
                        else if (tipodeServicio[i]==2)
                        {
                            telefono = telefono + 1;
                            acumuladora2 = montocomisión[i] + acumuladora2;
                            continuarConsulta = false;
                        }
                        else if (tipodeServicio[i]==3)
                        {
                            agua = agua + 1;
                            acumuladora3 = montocomisión[i] + acumuladora3;
                            continuarConsulta = false;
                        }

                    }
                    if (continuarConsulta)
                    {
                        Console.WriteLine("                         ");
                        Console.WriteLine( "        No hay pagos registrados          ");
                        Console.WriteLine("                         ");

                    }
                    else
                    {
                                                
                         Console.WriteLine($"1.Electricidad         {electricidad}           {acumuladora1}");
                         Console.WriteLine($"2.Telefono             {telefono}            {acumuladora2}");
                         Console.WriteLine($"1.Agua                 {agua}            {acumuladora3}");
                        
                    }
                    Console.WriteLine("========================================================");
                    Console.WriteLine($"total:                   {electricidad+telefono+agua}             {acumuladora1+acumuladora2+acumuladora3}        ");
                    break;
                case 5:
                    Console.WriteLine("Regresando al Menú Principal...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                    break;
            }

        } while (opcion != 5);
    }

}




        
    
