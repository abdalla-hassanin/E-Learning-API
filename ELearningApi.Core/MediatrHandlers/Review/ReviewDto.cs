namespace ELearningApi.Core.MediatrHandlers.Review
{
    public class ReviewDto
    {
        public Guid Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
    }
}