namespace Ejercicio_1.Models.DataModels;

public class Curso
{

    [Required]
    [Key]
    public int Id { get; set; }

    [Required, StringLength(100)]
    public string Nombre { get; set; } = string.Empty;

    [StringLength(280)]
    public string Descripcion_Corta { get; set; } = string.Empty;

    public string Descripcion_Larga { get; set; } = string.Empty;
    public string Publico_objetivo { get; set; } = string.Empty;
    public string Objetivos { get; set; } = string.Empty;
    public string Requisitos { get; set; } = string.Empty;
    public Level Nivel { get; set; }

    public enum Level{
        Basico = 0,
        Intermedio,
        Avanzado
    }
}