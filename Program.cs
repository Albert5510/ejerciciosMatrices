using System;

namespace ejerciciosMatrices
{
    class Program
    {
        static void Main(string[] args)
        {
            Ejercicio4.ejercicio4();
            //Ejercicio7.ejercicio7();
            //Ejercicio8.ejercicio8();
            Console.ReadKey();


        }
    }
    class Ejercicio4
    {
        /*Tenemos una tabla dentada de caracteres char[][] paises, 
        que tiene almacenados los nombres de 20 países.
        Se pide diseñar un programa que realice, tantas veces como sea requerido 
        por el usuario, las siguientes operaciones:

        Buscar un país.
        Mostrar países.
        Ordenar países.
        Añadir prefijo a un país.
        Otras consideraciones...

        El prefijo estará formado por 2 caracteres, habrá un espacio 
        en blanco entre el nombre y el prefijo. 
        Para añadir el prefijo a la fíla correspondiente del país, 
        puedes redimensionar la fila de la dentada usando el método:
        Array.Resize(ref paises[paisEncontrado], paises.Length+3)
        Para ordenar la dentada alfabéticamente, utilizaremos el método 
        de ordenación de la burbuja (hay un ejemplo en los apuntes). 
        Para comparar cadenas alfabéticamente debes usar el método CompareTo de cadena.
        👉Pista: para programar este ejercicio podemos pasar de array de char a string 
        o viceversa, cuando lo necesitemos. Recordar que para pasar de string a array 
        de char usaremos cadena.TocharArray() 
        y de array de char a string con new String(array)*/
        public static void ejercicio4()
        {
            bool salir = false;
            char[,] prefijos = new char[2, 2]
            {
               {'f','r'},
               {'i','t'}
            };
            string[] paises = new string[2] { "IT italia", "FR francia" };
            while (salir == false)
            {
                int opcion = tablaPaises();
                switch (opcion)
                {
                    case 1:
                        int[] posicion = buscarPais(prefijos);
                        System.Console.WriteLine("el pais es" + paises[posicion[0]]);
                        break;
                    case 2:
                        mostrarPaises(paises);
                        break;
                    case 3:
                        paises = ordenarPaises(paises);
                        break;
                    case 4:
                        añadirPrefijo(prefijos, paises);
                        break;
                    case 5:
                        salir = true;
                        break;

                }
            }

        }
        static int tablaPaises()
        {
            System.Console.WriteLine("buscar pais (1)");
            System.Console.WriteLine("mostrar pais (2)");
            System.Console.WriteLine("ordenar paises (3)");
            System.Console.WriteLine("añadir prefijo a un pais (4)");
            System.Console.WriteLine("otras consideraciones (5)");
            int opcion = Int32.Parse(Console.ReadLine());
            return opcion;
        }
        static int[] buscarPais(char[,] prefijos)
        {
            System.Console.WriteLine("dime un pais (prefijo)");
            string pais = Console.ReadLine();
            int[] resultado = new int[2];
            //ordenar()
            for (int i = 0; i < prefijos.GetLength(0); i++)

            {
                string auxiliar = "";
                for (int j = 0; j < prefijos.GetLength(1); j++)
                {
                    auxiliar += prefijos[i, j];
                    if (auxiliar.Equals(pais))
                    {
                        resultado[0] = i;
                        resultado[1] = j;
                    }
                }
            }
            return resultado;
        }

        static string[] ordenarPaises(string[] paises)
        {
            string[] paisesAux = paises;

            for (int i = 0; i < paisesAux.Length; i++)
            {
                for (int j = 0; j < paisesAux.Length - 1; j++)
                {
                    for (int k = 0; k < paisesAux.Length; k++)
                        if (paisesAux[j][k] > paisesAux[j + 1][k])
                        {
                            string temp = paisesAux[j];
                            paisesAux[j] = paisesAux[j + 1];
                            paisesAux[j + 1] = temp;
                        }

                }
            }

            mostrarPaises(paisesAux);
            return paisesAux;
        }
        static void añadirPrefijo(char[,] prefijos, string[] paises)
        {
            //Buscamos el pais
            int[] posicion = buscarPais(prefijos);
            //Cambiamos el prefijo
            Console.WriteLine("Escriba el nuevo prefijo");
            string nuevoPrefijo = Console.ReadLine();
            char[] charArray = nuevoPrefijo.ToCharArray();
            prefijos[posicion[0],0] = charArray[0];
            prefijos[posicion[0],1] = charArray[1];

            char[] charArray2 = paises[posicion[0]].ToCharArray();
            charArray2[0] = charArray[0];
            charArray2[1] = charArray[1];
            paises[posicion[0]] = new String(charArray2);

        }
        static void mostrarPaises(string[] paises)
        {
            for (int i = 0; i < paises.Length; i++)
            {
                Console.WriteLine(paises[i]);
            }
        }



    }
    class Ejercicio7
    {
        /*Escribe un programa que se encargue de controlar el aforo de un Multicine:

        El cine tendrá tres salas (A, B, C),
        en las cuales se pasarán diariamente tres sesiones (1ª, 2ª, 3ª).
        El número máximo de personas de cada una de las salas es:
        Sala A = 200 personas.
        Sala B = 150 personas.
        Sala C = 125 personas.
        Tendremos un menú con dos opciones:
        Venta de entradas.
        Estadística de aforo.
        Para salir del programa se tendrá que pulsar la tecla ESC.
        Cada vez que se realice una venta de entradas se pedirá:

        El número de entradas que se van a comprar.
        La sala
        La sesión a la que se quiere asistir.
        Las entradas vendidas quedarán registradas en la matriz bi-dimensional.
        Si el número de entradas sobrepasa el aforo máximo de la sala,
        se indicará mediante un mensaje por pantalla.

        En la opción de estadística de aforo, 
        se mostrará una tabla de la siguiente manera:

		Sesión1	        Sesión2	        Sesión3
        SalaA		178		100		99
        SalaB		12		50		100
        SalaC		32		101		55
        👉Pista: puedes plantearte la solución de dos formas distinta. 
        Inicializando todos los elementos de la matriz de 3X3 a 0 y en cada venta añadir, 
        al elemento correspondiente a los indices, 
        las entradas vendidas sin pasarse del afora de la sala. 
        La otra opción sería inicializar la matriz una fila a 200, 
        la otra a 150 y la última a 125, y en cada venta decrementar la cantidad vendida, 
        controlando de no vender si se ha llegado a 0.*/
        public static void ejercicio7()
        {
            int[][] entradas = new int[3][];
            entradas[0] = new int[3] { 200, 200, 200 };
            entradas[1] = new int[3] { 150, 150, 150 };
            entradas[2] = new int[3] { 125, 125, 125 };
            char opcion = '0';
            while (opcion != 'E')
            {
                opcion = mostrarMenu();
                if (opcion == '1')
                {
                    entradas = venderEntradas(entradas);
                }
                else if (opcion == '2')
                {
                    mostrarTabla(entradas);
                }

            }

        }

        public static char mostrarMenu()
        {
            System.Console.WriteLine("Elija una de las dos opciones:");
            System.Console.WriteLine("1. Venta de entradas");
            System.Console.WriteLine("2. Estadística de aforo");
            return char.Parse(Console.ReadLine());

        }

        public static int[][] venderEntradas(int[][] entradas)
        {

            int[][] entradasAuxiliar = entradas;
            int numeroEntradas, sesion, sala;

            System.Console.WriteLine("Elija la sala (inserte 1 para A, 2 para B, 3 para C):");
            sala = Int32.Parse(Console.ReadLine());
            if (sala >= 1 && sala <= 3)
            {
                System.Console.WriteLine("Elija la sesión (1º, 2º, 3º):");
                sesion = Int32.Parse(Console.ReadLine());
                if (sesion >= 1 && sesion <= 3)
                {
                    System.Console.WriteLine("Cuantas entradas quiere comprar?");
                    numeroEntradas = Int32.Parse(Console.ReadLine());
                    entradasAuxiliar[sala - 1][sesion - 1] = entradasAuxiliar[sala - 1][sesion - 1] - numeroEntradas;
                    if (entradasAuxiliar[sala - 1][sesion - 1] <= 0)
                    {
                        System.Console.WriteLine("Aforo maximo superado");
                    }
                }
            }
            return entradasAuxiliar;
        }

        public static void mostrarTabla(int[][] entradas)
        {
            Console.WriteLine("\tSesion 1\t Sesion 2\t Sesion 3");
            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        Console.Write("SalaA\t");
                        break;
                    case 1:
                        Console.Write("SalaB\t");
                        break;
                    case 2:
                        Console.Write("SalaC\t");
                        break;
                }
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(entradas[i][j]);
                    Console.Write('\t');
                }

                Console.Write('\n');
            }
        }
    }
    class Ejercicio8
    {
        /*Realiza un programa para crear un array de array de arrays de enteros.
        Para ello deberás crear una array de dos elementos, 
        donde cada elemento será una tabla dentada de enteros.
        El programa pedirá cuantas filas tiene y el número de elementos de cada fila, 
        para cada una de las tablas dentadas.
        Reservará la memoria para cada una 
        y rellenará la fila con los elementos generados de forma aleatoria.
        Posteriormente se mostrará el array de dos matrices dentadas de la siguiente forma:
        1,2,3,4                 13,14,15,16
        5,6,7                   17,18,19,20
        9,10,11,12	             21,22
        👉Pista: La tabla se creará de la siguiente manera int[][][] m = new int[2][][]. 
        Recuerda que las tablas se dimensionan con la palabra reservada new, 
        y deberás redimensionar tanto,
        el número de filas de cada tabla como el número de columnas que tiene cada fila.*/
        public static void ejercicio8()
        {

            int numeroDeFilas = 1;
            int elementosPorFila = 1;
            Random r = new Random();
            int[][][] m = new int[2][][];
            Console.WriteLine("Cuantas filas desea?");
            numeroDeFilas = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Cuantos elementos por fila desea?");
            elementosPorFila = Int32.Parse(Console.ReadLine());
            m[0] = new int[numeroDeFilas][];
            m[1] = new int[numeroDeFilas][];
            for (int i = 0; i < numeroDeFilas; i++)
            {
                m[0][i] = new int[elementosPorFila];
                for (int j = 0; j < elementosPorFila; j++)
                {
                    m[0][i][j] = r.Next(0, 100);
                }
            }

            for (int i = 0; i < numeroDeFilas; i++)
            {
                m[1][i] = new int[elementosPorFila];
                for (int j = 0; j < elementosPorFila; j++)
                {
                    m[1][i][j] = r.Next(0, 100);
                }
            }
            Console.WriteLine("Las matrices creadas son:");

            for (int y = 0; y < numeroDeFilas; y++)
            {
                for (int z = 0; z < elementosPorFila; z++)
                {
                    Console.Write(m[0][y][z]);
                    if (z != (elementosPorFila - 1))
                    {
                        Console.Write(',');
                    }
                    else
                    {
                        Console.Write("\t\t");
                    }
                }
                for (int x = 0; x < elementosPorFila; x++)
                {
                    Console.Write(m[1][y][x]);
                    if (x != (elementosPorFila - 1))
                    {
                        Console.Write(',');
                    }
                    else
                    {
                        Console.Write("\n");
                    }
                }
            }


        }

    }
}
