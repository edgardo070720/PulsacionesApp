using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.IO;
using System.Collections;

namespace DAL
{
    public class PersonaRepository
    {
        private string ruta = @"persona.txt";
        private List<Persona> personas;

        public void Guardar(Persona persona)
        {

            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{persona.Identificacion};{persona.Nombre};{persona.Edad};{persona.Sexo};{persona.pulsacion}");
            Console.WriteLine("se guardo correctamente en el archivo");
            escritor.Close();
            file.Close();
        }

        public List<Persona> Consultar()
        {
            personas = new List<Persona>();
            string line = string.Empty;
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            while ((line = reader.ReadLine()) != null)
            {
                Persona persona = new Persona();
                char separador = ';';
                string[] matrizPersona = line.Split(separador);
                persona.Identificacion = matrizPersona[0];
                persona.Nombre = matrizPersona[1];
                persona.Edad = Convert.ToInt32(matrizPersona[2]);
                persona.Sexo = matrizPersona[3];
                persona.pulsacion = Convert.ToDecimal(matrizPersona[4]);
                personas.Add(persona);
            }
            reader.Close();
            file.Close();
            return personas;

        }

        public void Actualizar(List<Persona> personas)
        {
            FileStream file = new FileStream(ruta, FileMode.Create);
            StreamWriter writer = new StreamWriter(file);
            foreach (Persona persona in personas)
            {
                writer.WriteLine($"{persona.Identificacion};{persona.Nombre};{persona.Edad};{persona.Sexo};{persona.pulsacion}"); 
            }
            writer.Close();
            file.Close();
        }
    }
}
