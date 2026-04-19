using CommunityToolkit.Mvvm.Input;
using ContempProgFinalProj.Models;

namespace ContempProgFinalProj.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}