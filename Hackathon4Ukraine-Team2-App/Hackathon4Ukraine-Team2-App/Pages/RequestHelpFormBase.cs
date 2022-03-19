using Hackathon4Ukraine_Team2_App.Domain;
using Hackathon4Ukraine_Team2_App.Extensions;
using Hackathon4Ukraine_Team2_App.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Hackathon4Ukraine_Team2_App.Pages;

public class RequestHelpFormBase : ComponentBase
{
    [Inject]
    private IRequestHelpService RequestHelpService { get; set; }
    [Inject]
    private ILogger<RequestHelpForm> Logger { get; set; }

    protected RequestHelp model = new();

    protected async Task HandleValidSubmit()
    {
        Logger.LogInformation("HandleValidSubmit called with + " + model.Name);
        if (model.Name.IsNullOrEmpty())
        {
            throw new InvalidOperationException("Name is required");
        }

        // Process the valid form
        await RequestHelpService.SaveRequest(model);
    }
}
