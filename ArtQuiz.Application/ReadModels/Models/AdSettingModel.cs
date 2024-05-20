namespace ArtQuiz.Application.ReadModels.Models;

public class AdSettingModel
{
    public Guid AdSettingId { get; set; }
    
    public int Probability { get; set; }
    
    public DateTime CreatedOn { get; set; }
}