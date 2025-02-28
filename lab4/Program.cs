using System;
using System.IO;

class Program
{
    static string directorio = "LaboratorioAvengers";
    static string archivo = Path.Combine(directorio, "inventos.txt");
    static string backupDir = "Backup";
    static string clasificadosDir = "ArchivosClasificados";
    static string proyectosDir = "ProyectosSecretos";

    static void Main()
    {
        Directory.CreateDirectory(directorio);
        Menu();
    }

    static void Menu()
    {
        while (true)
        {
            Console.WriteLine("\n--- Bienvenido a la Gestion de Inventos señor Stark ---");
            Console.WriteLine("1. Crear archivo");
            Console.WriteLine("2. Agregar invento");
            Console.WriteLine("3. Leer archivo línea por línea");
            Console.WriteLine("4. Leer todo el texto");
            Console.WriteLine("5. Copiar archivo");
            Console.WriteLine("6. Mover archivo");
            Console.WriteLine("7. Nueva carpeta");
            Console.WriteLine("8. Listar archivos");
            Console.WriteLine("9. Eliminar archivo");
            Console.WriteLine("10. Salir");
            Console.Write("Seleccione una opción: ");

            if (int.TryParse(Console.ReadLine(), out int opcion))
            {
                switch (opcion)
                {
                    case 1: CrearArchivo(); break;
                    case 2:
                        Console.Write("Ingrese nombre del invento: ");
                        AgregarInvento(Console.ReadLine());
                        break;
                    case 3: LeerLineaPorLinea(); break;
                    case 4: LeerTodoElTexto(); break;
                    case 5: CopiarArchivo(); break;
                    case 6: MoverArchivo(); break;
                    case 7: CrearCarpeta(); break;
                    case 8: ListarArchivos(); break;
                    case 9: EliminarArchivo(); break;
                    case 10: Console.WriteLine("*Saliendo de la gestion. Vuelva pronto señor Stark*...\n -JARVIS-");
                        return;
                    default: Console.WriteLine("Opcion invalida."); break;
                }
            }
            else
            {
                Console.WriteLine("Entrada invalida, vuelva a intentalo.");
            }
        }
    }

    static void CrearArchivo()
    {
        try
        {
            if (!File.Exists(archivo))
            {
                File.WriteAllText(archivo, "1. Traje Mark I\n2. Reactor Arc\n3. IA JARVIS\n");
                Console.WriteLine("Archivo creado de forma correcta!.");
            }
            else
            {
                Console.WriteLine("El archivo ya existe.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void AgregarInvento(string invento)
    {
        try
        {
            File.AppendAllText(archivo, invento + "\n");
            Console.WriteLine("Invento agregado!.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void LeerLineaPorLinea()
    {
        try
        {
            foreach (var linea in File.ReadLines(archivo))
            {
                Console.WriteLine(linea);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void LeerTodoElTexto()
    {
        try
        {
            Console.WriteLine(File.ReadAllText(archivo));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void CopiarArchivo()
    {
        try
        {
            Directory.CreateDirectory(backupDir);
            File.Copy(archivo, Path.Combine(backupDir, "inventos_backup.txt"), true);
            Console.WriteLine("Archivo copiado de forma correcta!.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void MoverArchivo()
    {
        try
        {
            Directory.CreateDirectory(clasificadosDir);
            string destino = Path.Combine(clasificadosDir, "inventos.txt");
            File.Move(archivo, destino, true);
            Console.WriteLine("Archivo movido de forma correcta!.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void CrearCarpeta()
    {
        try
        {
            Directory.CreateDirectory(proyectosDir);
            Console.WriteLine("Carpeta creada exitosamente!.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void ListarArchivos()
    {
        try
        {
            Console.WriteLine("Archivos en 'LaboratorioAvengers':");
            foreach (var file in Directory.GetFiles(directorio))
            {
                Console.WriteLine(Path.GetFileName(file));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void EliminarArchivo()
    {
        try
        {
            if (File.Exists(archivo))
            {
                File.Delete(archivo);
                Console.WriteLine("Archivo eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("El archivo no existe.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

