using Ardalis.Specification;

namespace MP_MB_MD.Core.ProjectAggregate.Specifications
{
    public class IncompleteItemsSpec : Specification<ToDoItem>
    {
        public IncompleteItemsSpec()
        {
            Query.Where(item => !item.IsDone);
        }
    }
}
