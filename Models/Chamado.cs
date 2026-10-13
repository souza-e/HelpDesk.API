using System;
using
System.ComponentModel.DataAnnotations;

namespace HelpDesk.API.Models;

public class Chamado
{
  /// <summary>
  /// Obtém ou define o identificador do chamado.
  /// </summary>
  public int Id { get; set; }

  [Required(ErrorMessage = "O título é obrigatório.")]
  [StringLength(100, ErrorMessage = "O título deve ter no máximo 100 caracteres.")]
  public string Titulo { get; set; } = string.Empty;

  [Required(ErrorMessage = "A descrição é obrigatória.")]
  [StringLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres.")]
  public string Descricao { get; set; } = string.Empty; //o string.Empty é usado para inicializar a propriedade com uma string vazia, evitando valores nulos.

  [Required(ErrorMessage = "O status é obrigatório.")]
  [RegularExpression ("^(Aberto|Em Andamento|Fechado)$", ErrorMessage = "O status deve ser 'Aberto', 'Em Andamento' ou 'Fechado'.")]
  public string Status { get; set; } = string.Empty;


  [Required(ErrorMessage = "A prioridade é obrigatória.")]
  [RegularExpression("^(Baixa|Média|Alta)$", ErrorMessage = "A prioridade deve ser 'Baixa', 'Média' ou 'Alta'.")]
  public string Prioridade { get; set; } = string.Empty;


}