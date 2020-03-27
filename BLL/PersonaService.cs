using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;
using System.Collections;

namespace BLL
{
    public class PersonaService
    {
        private PersonaRepository personaRepository;
        public PersonaService()
        {
            personaRepository = new PersonaRepository();
        }
        public decimal CalcularPulsacion(Persona persona)
        {

            if (persona.Sexo.ToUpper().Equals("F"))
            {
                return persona.pulsacion = (220 - persona.Edad) / 10;
            }
            else if (persona.Sexo.ToUpper().Equals("M"))
            {
                return persona.pulsacion = (210 - persona.Edad) / 10;
            }
            else
            {
                return  persona.pulsacion = 0;
            }
        }
        public void Guardar(Persona persona)
        {
            personaRepository.Guardar(persona);
            
        }
         public List<Persona> Consulatar()
        {
            return personaRepository.Consultar();
        }

        public void Eliminar(string documento)
        {
            List<Persona> personas = new List<Persona>();
            personas = personaRepository.Consultar();
            foreach (Persona persona in personas)
            {
                
                if (documento==persona.Identificacion)
                {
                    personas.Remove(persona);
                    personaRepository.Actualizar(personas);
                    Console.WriteLine("\nse elimino sus datos con exito");

                }
            }
            
        }
        public void ActualizarPersona(string documento)
        {
            List<Persona> personas = new List<Persona>();
            personas = personaRepository.Consultar();
            int control = 0, opcion;

            foreach (Persona  persona in personas )
            {
                if (documento==persona.Identificacion)
                {
                    while (control == 0)
                    {

                        Console.WriteLine("------MENU--DE---ACTUALIZACIONES--------------");
                        Console.WriteLine("1. documento ");
                        Console.WriteLine("2. nombre ");
                        Console.WriteLine("3. edad ");
                        Console.WriteLine("4. sexo ");
                        Console.WriteLine("5. guardar cambios ");
                        Console.WriteLine("\ndigite una opcion:  ");
                        opcion = Convert.ToInt32(Console.ReadLine());
                        switch (opcion)
                        {
                            case 1:
                                Console.WriteLine("-----------------------------------------");
                                Console.WriteLine("documento: ");
                                persona.Identificacion = Console.ReadLine(); break;
                            case 2:
                                Console.WriteLine("-----------------------------------------");
                                Console.WriteLine("nombre: ");
                                persona.Nombre = Console.ReadLine(); break;
                            case 3:
                                Console.WriteLine("-----------------------------------------");
                                Console.WriteLine("edad: " );
                                persona.Edad = Convert.ToInt32(Console.ReadLine()); break;
                            case 4:
                                Console.WriteLine("-----------------------------------------");
                                Console.WriteLine("sexo: ");
                                persona.Sexo = Console.ReadLine(); break;
                            case 5: control = 1; break;
                            default: Console.WriteLine("error al momento de digitar una opcion"); break;

                        }


                    }
                    persona.pulsacion = CalcularPulsacion(persona);
                    personaRepository.Actualizar(personas);


                }
            }
        }
    }
}
