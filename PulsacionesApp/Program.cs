using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using BLL;
using System.Collections;

namespace PulsacionesApp
{
    class Program
    {
        static void Main(string[] args)
        {

            PersonaService personaService = new PersonaService();
            int controlador = 0;
            while (controlador == 0)
            {
                Console.WriteLine("------------INICIO------------------------");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("1. registrar persona");
                Console.WriteLine("2. consultar persona");
                Console.WriteLine("3. eliminar  persona");
                Console.WriteLine("4. actualizar datos ");
                Console.WriteLine("5. salir");
                Console.WriteLine("digite una de las opciones: ");
                int opcion = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("-----------------------------------------");
                switch (opcion)
                {
                    case 1:Persona persona = RegistrarDatos();
                        personaService.CalcularPulsacion(persona);
                        personaService.Guardar(persona); break;
                    case 2: MostrarRegistroDeDatos(personaService); Console.ReadKey(); break;
                    case 3: Console.WriteLine("------------eliminar--datos--------------");
                        personaService.Eliminar(RecibirDocumento());break;
                    case 4: personaService.ActualizarPersona(RecibirDocumento());break;
                    case 5: controlador = 1; break;
                    default: Console.WriteLine("error al digitar una de las opciones"); break;
                }

            }
        }

        static public Persona RegistrarDatos()
        {
            Persona persona = new Persona();
            Console.WriteLine("--------------registrar---datos--------------------");
            Console.WriteLine("digite indentificacion");
            persona.Identificacion = Console.ReadLine();
            Console.WriteLine("digite nombre");
            persona.Nombre = Console.ReadLine();
            Console.WriteLine("digite edad");
            persona.Edad = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("digite sexo");
            persona.Sexo = Console.ReadLine();

            return persona;
        }
        static public void MostrarRegistroDeDatos(PersonaService personaService)
        {
            Console.WriteLine("lista de personas registradas");

            foreach (Persona registro in personaService.Consulatar())
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("indentificacion: " + registro.Identificacion);
                Console.WriteLine("nombre: " + registro.Nombre);
                Console.WriteLine("edad: " + registro.Edad);
                Console.WriteLine("sexo: " + registro.Sexo);
                Console.WriteLine("pulsaciones: " + registro.pulsacion);

            }
        }
        static public string RecibirDocumento()
        {
            Console.WriteLine("digite documento: ");
            string documento = Console.ReadLine();
            return documento;
        }

    }
}
