namespace NatuViva.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Suplemento
    {
        public int SuplementoId { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome pode ter no máximo 100 caracteres.")]
        [Display(Name = "Nome do Produto")]
        public string Nome{ get; set; }

        [Required(ErrorMessage = "Informe os benefícios do suplemento.")]
        [StringLength(500, ErrorMessage = "Os benefícios podem ter no máximo 500 caracteres.")]
        public string Beneficios { get; set; }

        //[Required(ErrorMessage = "A URL da imagem é obrigatória.")]
        //[Url(ErrorMessage = "Informe uma URL válida.")]
        [Display(Name = "URL da Imagem")]
        public string ImagemUrl { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Range(0.01, 9999.99, ErrorMessage = "O preço deve estar entre R$0,01 e R$9999,99.")]
        [Display(Name = "Preço")]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }
    }

}
