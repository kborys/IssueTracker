using IssueTracker.Core.Entities;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IssueTracker.Web.Helpers;

public static class HtmlHelpers
{
    private const string NoneSvg = """
                                       <svg xmlns="http://www.w3.org/2000/svg" height="22px" viewBox="0 -960 960 960" width="22px" fill="#434343">
                                           <path d="M424-320q0-81 14.5-116.5T500-514q41-36 62.5-62.5T584-637q0-41-27.5-68T480-732q-51 0-77.5 31T365-638l-103-44q21-64 77-111t141-47q105 0 161.5 58.5T698-641q0 50-21.5 85.5T609-475q-49 47-59.5 71.5T539-320H424Zm56 240q-33 0-56.5-23.5T400-160q0-33 23.5-56.5T480-240q33 0 56.5 23.5T560-160q0 33-23.5 56.5T480-80Z"/>
                                       </svg>
                                   """;

    private const string BugSvg = """
                                      <svg xmlns="http://www.w3.org/2000/svg" height="22px" viewBox="0 -960 960 960" width="22px" fill="#EA3323">
                                          <path d="M480-280q17 0 28.5-11.5T520-320q0-17-11.5-28.5T480-360q-17 0-28.5 11.5T440-320q0 17 11.5 28.5T480-280Zm-40-160h80v-240h-80v240Zm40 360q-83 0-156-31.5T197-197q-54-54-85.5-127T80-480q0-83 31.5-156T197-763q54-54 127-85.5T480-880q83 0 156 31.5T763-763q54 54 85.5 127T880-480q0 83-31.5 156T763-197q-54 54-127 85.5T480-80Z"/>
                                      </svg>
                                  """;

    private const string UserStorySvg = """
                                            <svg xmlns="http://www.w3.org/2000/svg" height="22px" viewBox="0 -960 960 960" width="22px" fill="#78A75A">
                                                <path d="M320-400h320v-22q0-44-44-71t-116-27q-72 0-116 27t-44 71v22Zm160-160q33 0 56.5-23.5T560-640q0-33-23.5-56.5T480-720q-33 0-56.5 23.5T400-640q0 33 23.5 56.5T480-560ZM80-80v-720q0-33 23.5-56.5T160-880h640q33 0 56.5 23.5T880-800v480q0 33-23.5 56.5T800-240H240L80-80Z"/>
                                            </svg>
                                        """;

    private const string EpicSvg = """
                                        <svg xmlns="http://www.w3.org/2000/svg" height="22px" viewBox="0 -960 960 960" width="22px" fill="#8C1AF6">
                                           <path d="m280-80 160-300-320-40 480-460h80L520-580l320 40L360-80h-80Z"/>
                                       </svg>
                                   """;

    public static HtmlString IssueTypeIcon(this IHtmlHelper helper, IssueType issueType, int size = 22)
    {
        return issueType switch
        {
            IssueType.None => new HtmlString(NoneSvg.Replace("22px", $"{size}px")),
            IssueType.Bug => new HtmlString(BugSvg.Replace("22px", $"{size}px")),
            IssueType.UserStory => new HtmlString(UserStorySvg.Replace("22px", $"{size}px")),
            IssueType.Epic => new HtmlString(EpicSvg.Replace("22px", $"{size}px")),
            _ => HtmlString.Empty
        };
    }

    /*
     *                 @if (issue.AssignedToAvatarUrl is not null || issue.AssignedToInitials is not null)
                {
                    @if (issue.AssignedToAvatarUrl != null) { <img src="@issue.AssignedToAvatarUrl" alt="avatar" class="rounded-full"/> }
                    else {  }
                }
                else
                {

                }
     */
    public static HtmlString UserAvatar(this IHtmlHelper helper, string? fullName, string? avatarUrl, int size)
    {
        if (fullName is null && avatarUrl is null)
        {
            return new HtmlString($"""
                                       <div class="rounded-full bg-slate-400 items-center" style="width:{size}px;height{size}px">
                                         <svg xmlns="http://www.w3.org/2000/svg" height="{size}px" viewBox="0 -960 960 960" width="{size}px" fill="#FFFFFF">
                                           <path d="M480-480q-66 0-113-47t-47-113q0-66 47-113t113-47q66 0 113 47t47 113q0 66-47 113t-113 47ZM160-160v-112q0-34 17.5-62.5T224-378q62-31 126-46.5T480-440q66 0 130 15.5T736-378q29 15 46.5 43.5T800-272v112H160Z"/>
                                         </svg>
                                       </div>
                                   """);
        }

        if (avatarUrl is null)
        {
            var initials = fullName?.Split(" ").Select(x => x[0]).Take(2).Aggregate("", (acc, x) => acc + x);
            return new HtmlString(
                $"""
                 <div>
                     <div class="rounded-full bg-red-200 font-medium" style="width:{size}px;line-height:{size}px;text-align:center">
                         <p>
                           {initials}
                         </p>
                     </div>
                 </div>

                 """);
        }


        return new HtmlString($$"""
                                <div style="width:{{size}}px;height:{{size}}px}">
                                    <img src="{{avatarUrl}}" alt="avatar" class="rounded-full" style="max-width:100%" />
                                </div>
                                """);
    }
}