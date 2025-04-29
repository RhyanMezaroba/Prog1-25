namespace Controle_Veterinário.Models
{
    public class VeterinariaModel
    {
        public class Animal
        {
            public int ID_Animal { get; set; }
            public string Nome_Animal { get; set; }
            public string Raca_Animal { get; set; }
            public int Idade_Animal { get; set; }
            public double Altura_Animal { get; set; }
        }

        public class Veterinario
        {
            public int ID_Veterinario { get; set; }
            public string Nome_Veterinario { get; set; }
            public string CRM_Veterinario { get; set; }
        }

        public class Procedimento
        {
            public int ID_Procedimento { get; set; }
            public string Nome_Procedimento { get; set; }
            public string Descricao_Procedimento { get; set; }
        }

        public class Atendimento
        {
            public int ID_Atendimento { get; set; }
            public int AnimalID { get; set; }
            public int VeterinarioID { get; set; }
            public List<int> ProcedimentoIDs { get; set; } = new();
            public DateTime Inicio { get; set; }
            public DateTime Fim { get; set; }
        }

    }
}
