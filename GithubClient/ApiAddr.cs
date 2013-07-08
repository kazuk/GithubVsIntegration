// ReSharper disable InconsistentNaming
using System.Diagnostics.Contracts;

namespace GithubClient
{
	internal static class ApiAddr
	{
        ///<summary>
        /// /events
        ///</summary>
        public static string Events(  )
        {
        		return string.Format("events"  );
        }
        ///<summary>
        /// /repos/:owner/:repo/events
        ///</summary>
        public static string ReposOwnerRepoEvents( string @owner, string @repo )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		return string.Format("repos/{0}/{1}/events" ,@owner, @repo );
        }
        ///<summary>
        /// /repos/:owner/:repo/issues/events
        ///</summary>
        public static string ReposOwnerRepoIssuesEvents( string @owner, string @repo )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		return string.Format("repos/{0}/{1}/issues/events" ,@owner, @repo );
        }
        ///<summary>
        /// /networks/:owner/:repo/events
        ///</summary>
        public static string NetworksOwnerRepoEvents( string @owner, string @repo )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		return string.Format("networks/{0}/{1}/events" ,@owner, @repo );
        }
        ///<summary>
        /// /orgs/:org/events
        ///</summary>
        public static string OrgsOrgEvents( string @org )
        {
        		Contract.Requires( @org!=null );
        		return string.Format("orgs/{0}/events" ,@org );
        }
        ///<summary>
        /// /users/:user/received_events
        ///</summary>
        public static string UsersUserReceived_events( string @user )
        {
        		Contract.Requires( @user!=null );
        		return string.Format("users/{0}/received_events" ,@user );
        }
        ///<summary>
        /// /users/:user/received_events/public
        ///</summary>
        public static string UsersUserReceived_eventsPublic( string @user )
        {
        		Contract.Requires( @user!=null );
        		return string.Format("users/{0}/received_events/public" ,@user );
        }
        ///<summary>
        /// /users/:user/events
        ///</summary>
        public static string UsersUserEvents( string @user )
        {
        		Contract.Requires( @user!=null );
        		return string.Format("users/{0}/events" ,@user );
        }
        ///<summary>
        /// /users/:user/events/public
        ///</summary>
        public static string UsersUserEventsPublic( string @user )
        {
        		Contract.Requires( @user!=null );
        		return string.Format("users/{0}/events/public" ,@user );
        }
        ///<summary>
        /// /users/:user/events/orgs/:org
        ///</summary>
        public static string UsersUserEventsOrgsOrg( string @user, string @org )
        {
        		Contract.Requires( @user!=null );
        		Contract.Requires( @org!=null );
        		return string.Format("users/{0}/events/orgs/{1}" ,@user, @org );
        }
        ///<summary>
        /// /feeds
        ///</summary>
        public static string Feeds(  )
        {
        		return string.Format("feeds"  );
        }
        ///<summary>
        /// /notifications
        ///</summary>
        public static string Notifications(  )
        {
        		return string.Format("notifications"  );
        }
        ///<summary>
        /// /repos/:owner/:repo/notifications
        ///</summary>
        public static string ReposOwnerRepoNotifications( string @owner, string @repo )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		return string.Format("repos/{0}/{1}/notifications" ,@owner, @repo );
        }
        ///<summary>
        /// /notifications/threads/:id
        ///</summary>
        public static string NotificationsThreadsId( string @id )
        {
        		Contract.Requires( @id!=null );
        		return string.Format("notifications/threads/{0}" ,@id );
        }
        ///<summary>
        /// /notifications/threads/:id/subscription
        ///</summary>
        public static string NotificationsThreadsIdSubscription( string @id )
        {
        		Contract.Requires( @id!=null );
        		return string.Format("notifications/threads/{0}/subscription" ,@id );
        }
        ///<summary>
        /// /repos/:owner/:repo/stargazers
        ///</summary>
        public static string ReposOwnerRepoStargazers( string @owner, string @repo )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		return string.Format("repos/{0}/{1}/stargazers" ,@owner, @repo );
        }
        ///<summary>
        /// /users/:user/starred
        ///</summary>
        public static string UsersUserStarred( string @user )
        {
        		Contract.Requires( @user!=null );
        		return string.Format("users/{0}/starred" ,@user );
        }
        ///<summary>
        /// /user/starred
        ///</summary>
        public static string UserStarred(  )
        {
        		return string.Format("user/starred"  );
        }
        ///<summary>
        /// /user/starred/:owner/:repo
        ///</summary>
        public static string UserStarredOwnerRepo( string @owner, string @repo )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		return string.Format("user/starred/{0}/{1}" ,@owner, @repo );
        }
        ///<summary>
        /// /repos/:owner/:repo/subscribers
        ///</summary>
        public static string ReposOwnerRepoSubscribers( string @owner, string @repo )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		return string.Format("repos/{0}/{1}/subscribers" ,@owner, @repo );
        }
        ///<summary>
        /// /users/:user/subscriptions
        ///</summary>
        public static string UsersUserSubscriptions( string @user )
        {
        		Contract.Requires( @user!=null );
        		return string.Format("users/{0}/subscriptions" ,@user );
        }
        ///<summary>
        /// /user/subscriptions
        ///</summary>
        public static string UserSubscriptions(  )
        {
        		return string.Format("user/subscriptions"  );
        }
        ///<summary>
        /// /repos/:owner/:repo/subscription
        ///</summary>
        public static string ReposOwnerRepoSubscription( string @owner, string @repo )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		return string.Format("repos/{0}/{1}/subscription" ,@owner, @repo );
        }
        ///<summary>
        /// /users/:user/gists
        ///</summary>
        public static string UsersUserGists( string @user )
        {
        		Contract.Requires( @user!=null );
        		return string.Format("users/{0}/gists" ,@user );
        }
        ///<summary>
        /// /gists
        ///</summary>
        public static string Gists(  )
        {
        		return string.Format("gists"  );
        }
        ///<summary>
        /// /gists/public
        ///</summary>
        public static string GistsPublic(  )
        {
        		return string.Format("gists/public"  );
        }
        ///<summary>
        /// /gists/starred
        ///</summary>
        public static string GistsStarred(  )
        {
        		return string.Format("gists/starred"  );
        }
        ///<summary>
        /// /gists/:id
        ///</summary>
        public static string GistsId( string @id )
        {
        		Contract.Requires( @id!=null );
        		return string.Format("gists/{0}" ,@id );
        }
        ///<summary>
        /// /gists/:id/star
        ///</summary>
        public static string GistsIdStar( string @id )
        {
        		Contract.Requires( @id!=null );
        		return string.Format("gists/{0}/star" ,@id );
        }
        ///<summary>
        /// /gists/:id/forks
        ///</summary>
        public static string GistsIdForks( string @id )
        {
        		Contract.Requires( @id!=null );
        		return string.Format("gists/{0}/forks" ,@id );
        }
        ///<summary>
        /// /gists/:gist_id/comments
        ///</summary>
        public static string GistsGist_idComments( string @gist_id )
        {
        		Contract.Requires( @gist_id!=null );
        		return string.Format("gists/{0}/comments" ,@gist_id );
        }
        ///<summary>
        /// /gists/:gist_id/comments/:id
        ///</summary>
        public static string GistsGist_idCommentsId( string @gist_id, string @id )
        {
        		Contract.Requires( @gist_id!=null );
        		Contract.Requires( @id!=null );
        		return string.Format("gists/{0}/comments/{1}" ,@gist_id, @id );
        }
        ///<summary>
        /// /repos/:owner/:repo/git/blobs/:sha
        ///</summary>
        public static string ReposOwnerRepoGitBlobsSha( string @owner, string @repo, string @sha )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		Contract.Requires( @sha!=null );
        		return string.Format("repos/{0}/{1}/git/blobs/{2}" ,@owner, @repo, @sha );
        }
        ///<summary>
        /// /repos/:owner/:repo/git/blobs
        ///</summary>
        public static string ReposOwnerRepoGitBlobs( string @owner, string @repo )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		return string.Format("repos/{0}/{1}/git/blobs" ,@owner, @repo );
        }
        ///<summary>
        /// /repos/:owner/:repo/git/commits/:sha
        ///</summary>
        public static string ReposOwnerRepoGitCommitsSha( string @owner, string @repo, string @sha )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		Contract.Requires( @sha!=null );
        		return string.Format("repos/{0}/{1}/git/commits/{2}" ,@owner, @repo, @sha );
        }
        ///<summary>
        /// /repos/:owner/:repo/git/commits
        ///</summary>
        public static string ReposOwnerRepoGitCommits( string @owner, string @repo )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		return string.Format("repos/{0}/{1}/git/commits" ,@owner, @repo );
        }
        ///<summary>
        /// /repos/:owner/:repo/git/refs/:ref
        ///</summary>
        public static string ReposOwnerRepoGitRefsRef( string @owner, string @repo, string @ref )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		Contract.Requires( @ref!=null );
        		return string.Format("repos/{0}/{1}/git/refs/{2}" ,@owner, @repo, @ref );
        }
        ///<summary>
        /// /repos/:owner/:repo/git/refs
        ///</summary>
        public static string ReposOwnerRepoGitRefs( string @owner, string @repo )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		return string.Format("repos/{0}/{1}/git/refs" ,@owner, @repo );
        }
        ///<summary>
        /// /repos/:owner/:repo/git/refs/tags
        ///</summary>
        public static string ReposOwnerRepoGitRefsTags( string @owner, string @repo )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		return string.Format("repos/{0}/{1}/git/refs/tags" ,@owner, @repo );
        }
        ///<summary>
        /// /repos/:owner/:repo/git/tags/:sha
        ///</summary>
        public static string ReposOwnerRepoGitTagsSha( string @owner, string @repo, string @sha )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		Contract.Requires( @sha!=null );
        		return string.Format("repos/{0}/{1}/git/tags/{2}" ,@owner, @repo, @sha );
        }
        ///<summary>
        /// /repos/:owner/:repo/git/tags
        ///</summary>
        public static string ReposOwnerRepoGitTags( string @owner, string @repo )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		return string.Format("repos/{0}/{1}/git/tags" ,@owner, @repo );
        }
        ///<summary>
        /// /repos/:owner/:repo/git/trees/:sha
        ///</summary>
        public static string ReposOwnerRepoGitTreesSha( string @owner, string @repo, string @sha )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		Contract.Requires( @sha!=null );
        		return string.Format("repos/{0}/{1}/git/trees/{2}" ,@owner, @repo, @sha );
        }
        ///<summary>
        /// /repos/:owner/:repo/git/trees
        ///</summary>
        public static string ReposOwnerRepoGitTrees( string @owner, string @repo )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		return string.Format("repos/{0}/{1}/git/trees" ,@owner, @repo );
        }
        ///<summary>
        /// /issues
        ///</summary>
        public static string Issues(  )
        {
        		return string.Format("issues"  );
        }
        ///<summary>
        /// /user/issues
        ///</summary>
        public static string UserIssues(  )
        {
        		return string.Format("user/issues"  );
        }
        ///<summary>
        /// /orgs/:org/issues
        ///</summary>
        public static string OrgsOrgIssues( string @org )
        {
        		Contract.Requires( @org!=null );
        		return string.Format("orgs/{0}/issues" ,@org );
        }
        ///<summary>
        /// /repos/:owner/:repo/issues
        ///</summary>
        public static string ReposOwnerRepoIssues( string @owner, string @repo )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		return string.Format("repos/{0}/{1}/issues" ,@owner, @repo );
        }
        ///<summary>
        /// /repos/:owner/:repo/issues/:number
        ///</summary>
        public static string ReposOwnerRepoIssuesNumber( string @owner, string @repo, string @number )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		Contract.Requires( @number!=null );
        		return string.Format("repos/{0}/{1}/issues/{2}" ,@owner, @repo, @number );
        }
        ///<summary>
        /// /repos/:owner/:repo/assignees
        ///</summary>
        public static string ReposOwnerRepoAssignees( string @owner, string @repo )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		return string.Format("repos/{0}/{1}/assignees" ,@owner, @repo );
        }
        ///<summary>
        /// /repos/:owner/:repo/assignees/:assignee
        ///</summary>
        public static string ReposOwnerRepoAssigneesAssignee( string @owner, string @repo, string @assignee )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		Contract.Requires( @assignee!=null );
        		return string.Format("repos/{0}/{1}/assignees/{2}" ,@owner, @repo, @assignee );
        }
        ///<summary>
        /// /repos/:owner/:repo/issues/:number/comments
        ///</summary>
        public static string ReposOwnerRepoIssuesNumberComments( string @owner, string @repo, string @number )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		Contract.Requires( @number!=null );
        		return string.Format("repos/{0}/{1}/issues/{2}/comments" ,@owner, @repo, @number );
        }
        ///<summary>
        /// /repos/:owner/:repo/issues/comments
        ///</summary>
        public static string ReposOwnerRepoIssuesComments( string @owner, string @repo )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		return string.Format("repos/{0}/{1}/issues/comments" ,@owner, @repo );
        }
        ///<summary>
        /// /repos/:owner/:repo/issues/comments/:id
        ///</summary>
        public static string ReposOwnerRepoIssuesCommentsId( string @owner, string @repo, string @id )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		Contract.Requires( @id!=null );
        		return string.Format("repos/{0}/{1}/issues/comments/{2}" ,@owner, @repo, @id );
        }
        ///<summary>
        /// /repos/:owner/:repo/issues/:issue_number/events
        ///</summary>
        public static string ReposOwnerRepoIssuesIssue_numberEvents( string @owner, string @repo, string @issue_number )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		Contract.Requires( @issue_number!=null );
        		return string.Format("repos/{0}/{1}/issues/{2}/events" ,@owner, @repo, @issue_number );
        }
        ///<summary>
        /// /repos/:owner/:repo/issues/events/:id
        ///</summary>
        public static string ReposOwnerRepoIssuesEventsId( string @owner, string @repo, string @id )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		Contract.Requires( @id!=null );
        		return string.Format("repos/{0}/{1}/issues/events/{2}" ,@owner, @repo, @id );
        }
        ///<summary>
        /// /repos/:owner/:repo/labels
        ///</summary>
        public static string ReposOwnerRepoLabels( string @owner, string @repo )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		return string.Format("repos/{0}/{1}/labels" ,@owner, @repo );
        }
        ///<summary>
        /// /repos/:owner/:repo/labels/:name
        ///</summary>
        public static string ReposOwnerRepoLabelsName( string @owner, string @repo, string @name )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		Contract.Requires( @name!=null );
        		return string.Format("repos/{0}/{1}/labels/{2}" ,@owner, @repo, @name );
        }
        ///<summary>
        /// /repos/:owner/:repo/issues/:number/labels
        ///</summary>
        public static string ReposOwnerRepoIssuesNumberLabels( string @owner, string @repo, string @number )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		Contract.Requires( @number!=null );
        		return string.Format("repos/{0}/{1}/issues/{2}/labels" ,@owner, @repo, @number );
        }
        ///<summary>
        /// /repos/:owner/:repo/issues/:number/labels/:name
        ///</summary>
        public static string ReposOwnerRepoIssuesNumberLabelsName( string @owner, string @repo, string @number, string @name )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		Contract.Requires( @number!=null );
        		Contract.Requires( @name!=null );
        		return string.Format("repos/{0}/{1}/issues/{2}/labels/{3}" ,@owner, @repo, @number, @name );
        }
        ///<summary>
        /// /repos/:owner/:repo/milestones/:number/labels
        ///</summary>
        public static string ReposOwnerRepoMilestonesNumberLabels( string @owner, string @repo, string @number )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		Contract.Requires( @number!=null );
        		return string.Format("repos/{0}/{1}/milestones/{2}/labels" ,@owner, @repo, @number );
        }
        ///<summary>
        /// /repos/:owner/:repo/milestones
        ///</summary>
        public static string ReposOwnerRepoMilestones( string @owner, string @repo )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		return string.Format("repos/{0}/{1}/milestones" ,@owner, @repo );
        }
        ///<summary>
        /// /repos/:owner/:repo/milestones/:number
        ///</summary>
        public static string ReposOwnerRepoMilestonesNumber( string @owner, string @repo, string @number )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		Contract.Requires( @number!=null );
        		return string.Format("repos/{0}/{1}/milestones/{2}" ,@owner, @repo, @number );
        }
        ///<summary>
        /// /users/:user/orgs
        ///</summary>
        public static string UsersUserOrgs( string @user )
        {
        		Contract.Requires( @user!=null );
        		return string.Format("users/{0}/orgs" ,@user );
        }
        ///<summary>
        /// /user/orgs
        ///</summary>
        public static string UserOrgs(  )
        {
        		return string.Format("user/orgs"  );
        }
        ///<summary>
        /// /orgs/:org
        ///</summary>
        public static string OrgsOrg( string @org )
        {
        		Contract.Requires( @org!=null );
        		return string.Format("orgs/{0}" ,@org );
        }
        ///<summary>
        /// /orgs/:org/members
        ///</summary>
        public static string OrgsOrgMembers( string @org )
        {
        		Contract.Requires( @org!=null );
        		return string.Format("orgs/{0}/members" ,@org );
        }
        ///<summary>
        /// /orgs/:org/members/:user
        ///</summary>
        public static string OrgsOrgMembersUser( string @org, string @user )
        {
        		Contract.Requires( @org!=null );
        		Contract.Requires( @user!=null );
        		return string.Format("orgs/{0}/members/{1}" ,@org, @user );
        }
        ///<summary>
        /// /orgs/:org/public_members
        ///</summary>
        public static string OrgsOrgPublic_members( string @org )
        {
        		Contract.Requires( @org!=null );
        		return string.Format("orgs/{0}/public_members" ,@org );
        }
        ///<summary>
        /// /orgs/:org/public_members/:user
        ///</summary>
        public static string OrgsOrgPublic_membersUser( string @org, string @user )
        {
        		Contract.Requires( @org!=null );
        		Contract.Requires( @user!=null );
        		return string.Format("orgs/{0}/public_members/{1}" ,@org, @user );
        }
        ///<summary>
        /// /orgs/:org/teams
        ///</summary>
        public static string OrgsOrgTeams( string @org )
        {
        		Contract.Requires( @org!=null );
        		return string.Format("orgs/{0}/teams" ,@org );
        }
        ///<summary>
        /// /teams/:id
        ///</summary>
        public static string TeamsId( string @id )
        {
        		Contract.Requires( @id!=null );
        		return string.Format("teams/{0}" ,@id );
        }
        ///<summary>
        /// /teams/:id/members
        ///</summary>
        public static string TeamsIdMembers( string @id )
        {
        		Contract.Requires( @id!=null );
        		return string.Format("teams/{0}/members" ,@id );
        }
        ///<summary>
        /// /teams/:id/members/:user
        ///</summary>
        public static string TeamsIdMembersUser( string @id, string @user )
        {
        		Contract.Requires( @id!=null );
        		Contract.Requires( @user!=null );
        		return string.Format("teams/{0}/members/{1}" ,@id, @user );
        }
        ///<summary>
        /// /teams/:id/repos
        ///</summary>
        public static string TeamsIdRepos( string @id )
        {
        		Contract.Requires( @id!=null );
        		return string.Format("teams/{0}/repos" ,@id );
        }
        ///<summary>
        /// /teams/:id/repos/:owner/:repo
        ///</summary>
        public static string TeamsIdReposOwnerRepo( string @id, string @owner, string @repo )
        {
        		Contract.Requires( @id!=null );
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		return string.Format("teams/{0}/repos/{1}/{2}" ,@id, @owner, @repo );
        }
        ///<summary>
        /// /teams/:id/repos/:org/:repo
        ///</summary>
        public static string TeamsIdReposOrgRepo( string @id, string @org, string @repo )
        {
        		Contract.Requires( @id!=null );
        		Contract.Requires( @org!=null );
        		Contract.Requires( @repo!=null );
        		return string.Format("teams/{0}/repos/{1}/{2}" ,@id, @org, @repo );
        }
        ///<summary>
        /// /repos/:owner/:repo/pulls
        ///</summary>
        public static string ReposOwnerRepoPulls( string @owner, string @repo )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		return string.Format("repos/{0}/{1}/pulls" ,@owner, @repo );
        }
        ///<summary>
        /// /repos/:owner/:repo/pulls/:number
        ///</summary>
        public static string ReposOwnerRepoPullsNumber( string @owner, string @repo, string @number )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		Contract.Requires( @number!=null );
        		return string.Format("repos/{0}/{1}/pulls/{2}" ,@owner, @repo, @number );
        }
        ///<summary>
        /// /repos/:owner/:repo/pulls/:number/commits
        ///</summary>
        public static string ReposOwnerRepoPullsNumberCommits( string @owner, string @repo, string @number )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		Contract.Requires( @number!=null );
        		return string.Format("repos/{0}/{1}/pulls/{2}/commits" ,@owner, @repo, @number );
        }
        ///<summary>
        /// /repos/:owner/:repo/pulls/:number/files
        ///</summary>
        public static string ReposOwnerRepoPullsNumberFiles( string @owner, string @repo, string @number )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		Contract.Requires( @number!=null );
        		return string.Format("repos/{0}/{1}/pulls/{2}/files" ,@owner, @repo, @number );
        }
        ///<summary>
        /// /repos/:owner/:repo/pulls/:number/merge
        ///</summary>
        public static string ReposOwnerRepoPullsNumberMerge( string @owner, string @repo, string @number )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		Contract.Requires( @number!=null );
        		return string.Format("repos/{0}/{1}/pulls/{2}/merge" ,@owner, @repo, @number );
        }
        ///<summary>
        /// /repos/:owner/:repo/pulls/:number/comments
        ///</summary>
        public static string ReposOwnerRepoPullsNumberComments( string @owner, string @repo, string @number )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		Contract.Requires( @number!=null );
        		return string.Format("repos/{0}/{1}/pulls/{2}/comments" ,@owner, @repo, @number );
        }
        ///<summary>
        /// /repos/:owner/:repo/pulls/comments
        ///</summary>
        public static string ReposOwnerRepoPullsComments( string @owner, string @repo )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		return string.Format("repos/{0}/{1}/pulls/comments" ,@owner, @repo );
        }
        ///<summary>
        /// /repos/:owner/:repo/pulls/comments/:number
        ///</summary>
        public static string ReposOwnerRepoPullsCommentsNumber( string @owner, string @repo, string @number )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		Contract.Requires( @number!=null );
        		return string.Format("repos/{0}/{1}/pulls/comments/{2}" ,@owner, @repo, @number );
        }
        ///<summary>
        /// /user/repos
        ///</summary>
        public static string UserRepos(  )
        {
        		return string.Format("user/repos"  );
        }
        ///<summary>
        /// /users/:user/repos
        ///</summary>
        public static string UsersUserRepos( string @user )
        {
        		Contract.Requires( @user!=null );
        		return string.Format("users/{0}/repos" ,@user );
        }
        ///<summary>
        /// /orgs/:org/repos
        ///</summary>
        public static string OrgsOrgRepos( string @org )
        {
        		Contract.Requires( @org!=null );
        		return string.Format("orgs/{0}/repos" ,@org );
        }
        ///<summary>
        /// /repositories
        ///</summary>
        public static string Repositories(  )
        {
        		return string.Format("repositories"  );
        }
        ///<summary>
        /// /repos/:owner/:repo
        ///</summary>
        public static string ReposOwnerRepo( string @owner, string @repo )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		return string.Format("repos/{0}/{1}" ,@owner, @repo );
        }
        ///<summary>
        /// /repos/:owner/:repo/contributors
        ///</summary>
        public static string ReposOwnerRepoContributors( string @owner, string @repo )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		return string.Format("repos/{0}/{1}/contributors" ,@owner, @repo );
        }
        ///<summary>
        /// /repos/:owner/:repo/tags
        ///</summary>
        public static string ReposOwnerRepoTags( string @owner, string @repo )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		return string.Format("repos/{0}/{1}/tags" ,@owner, @repo );
        }
        ///<summary>
        /// /repos/:owner/:repo/branches
        ///</summary>
        public static string ReposOwnerRepoBranches( string @owner, string @repo )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		return string.Format("repos/{0}/{1}/branches" ,@owner, @repo );
        }
        ///<summary>
        /// /repos/:owner/:repo/branches/:branch
        ///</summary>
        public static string ReposOwnerRepoBranchesBranch( string @owner, string @repo, string @branch )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		Contract.Requires( @branch!=null );
        		return string.Format("repos/{0}/{1}/branches/{2}" ,@owner, @repo, @branch );
        }
        ///<summary>
        /// /repos/:owner/:repo/collaborators
        ///</summary>
        public static string ReposOwnerRepoCollaborators( string @owner, string @repo )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		return string.Format("repos/{0}/{1}/collaborators" ,@owner, @repo );
        }
        ///<summary>
        /// /repos/:owner/:repo/collaborators/:user
        ///</summary>
        public static string ReposOwnerRepoCollaboratorsUser( string @owner, string @repo, string @user )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		Contract.Requires( @user!=null );
        		return string.Format("repos/{0}/{1}/collaborators/{2}" ,@owner, @repo, @user );
        }
        ///<summary>
        /// /repos/:owner/:repo/comments
        ///</summary>
        public static string ReposOwnerRepoComments( string @owner, string @repo )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		return string.Format("repos/{0}/{1}/comments" ,@owner, @repo );
        }
        ///<summary>
        /// /repos/:owner/:repo/commits/:sha/comments
        ///</summary>
        public static string ReposOwnerRepoCommitsShaComments( string @owner, string @repo, string @sha )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		Contract.Requires( @sha!=null );
        		return string.Format("repos/{0}/{1}/commits/{2}/comments" ,@owner, @repo, @sha );
        }
        ///<summary>
        /// /repos/:owner/:repo/comments/:id
        ///</summary>
        public static string ReposOwnerRepoCommentsId( string @owner, string @repo, string @id )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		Contract.Requires( @id!=null );
        		return string.Format("repos/{0}/{1}/comments/{2}" ,@owner, @repo, @id );
        }
        ///<summary>
        /// /repos/:owner/:repo/commits
        ///</summary>
        public static string ReposOwnerRepoCommits( string @owner, string @repo )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		return string.Format("repos/{0}/{1}/commits" ,@owner, @repo );
        }
        ///<summary>
        /// /repos/:owner/:repo/commits/:sha
        ///</summary>
        public static string ReposOwnerRepoCommitsSha( string @owner, string @repo, string @sha )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		Contract.Requires( @sha!=null );
        		return string.Format("repos/{0}/{1}/commits/{2}" ,@owner, @repo, @sha );
        }
        ///<summary>
        /// /repos/:owner/:repo/compare/:base
        ///</summary>
        public static string ReposOwnerRepoCompareBase( string @owner, string @repo, string @base )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		Contract.Requires( @base!=null );
        		return string.Format("repos/{0}/{1}/compare/{2}" ,@owner, @repo, @base );
        }
        ///<summary>
        /// /repos/:owner/:repo/readme
        ///</summary>
        public static string ReposOwnerRepoReadme( string @owner, string @repo )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		return string.Format("repos/{0}/{1}/readme" ,@owner, @repo );
        }
        ///<summary>
        /// /repos/:owner/:repo/contents/:path
        ///</summary>
        public static string ReposOwnerRepoContentsPath( string @owner, string @repo, string @path )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		Contract.Requires( @path!=null );
        		return string.Format("repos/{0}/{1}/contents/{2}" ,@owner, @repo, @path );
        }
        ///<summary>
        /// /repos/:owner/:repo/:archive_format/:ref
        ///</summary>
        public static string ReposOwnerRepoArchive_formatRef( string @owner, string @repo, string @archive_format, string @ref )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		Contract.Requires( @archive_format!=null );
        		Contract.Requires( @ref!=null );
        		return string.Format("repos/{0}/{1}/{2}/{3}" ,@owner, @repo, @archive_format, @ref );
        }
        ///<summary>
        /// /repos/:owner/:repo/downloads
        ///</summary>
        public static string ReposOwnerRepoDownloads( string @owner, string @repo )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		return string.Format("repos/{0}/{1}/downloads" ,@owner, @repo );
        }
        ///<summary>
        /// /repos/:owner/:repo/downloads/:id
        ///</summary>
        public static string ReposOwnerRepoDownloadsId( string @owner, string @repo, string @id )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		Contract.Requires( @id!=null );
        		return string.Format("repos/{0}/{1}/downloads/{2}" ,@owner, @repo, @id );
        }
        ///<summary>
        /// /repos/:owner/:repo/forks
        ///</summary>
        public static string ReposOwnerRepoForks( string @owner, string @repo )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		return string.Format("repos/{0}/{1}/forks" ,@owner, @repo );
        }
        ///<summary>
        /// /repos/:owner/:repo/keys
        ///</summary>
        public static string ReposOwnerRepoKeys( string @owner, string @repo )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		return string.Format("repos/{0}/{1}/keys" ,@owner, @repo );
        }
        ///<summary>
        /// /repos/:owner/:repo/keys/:id
        ///</summary>
        public static string ReposOwnerRepoKeysId( string @owner, string @repo, string @id )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		Contract.Requires( @id!=null );
        		return string.Format("repos/{0}/{1}/keys/{2}" ,@owner, @repo, @id );
        }
        ///<summary>
        /// /repos/:owner/:repo/hooks
        ///</summary>
        public static string ReposOwnerRepoHooks( string @owner, string @repo )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		return string.Format("repos/{0}/{1}/hooks" ,@owner, @repo );
        }
        ///<summary>
        /// /repos/:owner/:repo/hooks/:id
        ///</summary>
        public static string ReposOwnerRepoHooksId( string @owner, string @repo, string @id )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		Contract.Requires( @id!=null );
        		return string.Format("repos/{0}/{1}/hooks/{2}" ,@owner, @repo, @id );
        }
        ///<summary>
        /// /repos/:owner/:repo/hooks/:id/tests
        ///</summary>
        public static string ReposOwnerRepoHooksIdTests( string @owner, string @repo, string @id )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		Contract.Requires( @id!=null );
        		return string.Format("repos/{0}/{1}/hooks/{2}/tests" ,@owner, @repo, @id );
        }
        ///<summary>
        /// /repos/:owner/:repo/merges
        ///</summary>
        public static string ReposOwnerRepoMerges( string @owner, string @repo )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		return string.Format("repos/{0}/{1}/merges" ,@owner, @repo );
        }
        ///<summary>
        /// /repos/:owner/:repo/stats/contributors
        ///</summary>
        public static string ReposOwnerRepoStatsContributors( string @owner, string @repo )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		return string.Format("repos/{0}/{1}/stats/contributors" ,@owner, @repo );
        }
        ///<summary>
        /// /repos/:owner/:repo/stats/commit_activity
        ///</summary>
        public static string ReposOwnerRepoStatsCommit_activity( string @owner, string @repo )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		return string.Format("repos/{0}/{1}/stats/commit_activity" ,@owner, @repo );
        }
        ///<summary>
        /// /repos/:owner/:repo/stats/code_frequency
        ///</summary>
        public static string ReposOwnerRepoStatsCode_frequency( string @owner, string @repo )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		return string.Format("repos/{0}/{1}/stats/code_frequency" ,@owner, @repo );
        }
        ///<summary>
        /// /repos/:owner/:repo/stats/participation
        ///</summary>
        public static string ReposOwnerRepoStatsParticipation( string @owner, string @repo )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		return string.Format("repos/{0}/{1}/stats/participation" ,@owner, @repo );
        }
        ///<summary>
        /// /repos/:owner/:repo/stats/punch_card
        ///</summary>
        public static string ReposOwnerRepoStatsPunch_card( string @owner, string @repo )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		return string.Format("repos/{0}/{1}/stats/punch_card" ,@owner, @repo );
        }
        ///<summary>
        /// /repos/:owner/:repo/statuses/:ref
        ///</summary>
        public static string ReposOwnerRepoStatusesRef( string @owner, string @repo, string @ref )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		Contract.Requires( @ref!=null );
        		return string.Format("repos/{0}/{1}/statuses/{2}" ,@owner, @repo, @ref );
        }
        ///<summary>
        /// /repos/:owner/:repo/statuses/:sha
        ///</summary>
        public static string ReposOwnerRepoStatusesSha( string @owner, string @repo, string @sha )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repo!=null );
        		Contract.Requires( @sha!=null );
        		return string.Format("repos/{0}/{1}/statuses/{2}" ,@owner, @repo, @sha );
        }
        ///<summary>
        /// /users/:user
        ///</summary>
        public static string UsersUser( string @user )
        {
        		Contract.Requires( @user!=null );
        		return string.Format("users/{0}" ,@user );
        }
        ///<summary>
        /// /user
        ///</summary>
        public static string User(  )
        {
        		return string.Format("user"  );
        }
        ///<summary>
        /// /users
        ///</summary>
        public static string Users(  )
        {
        		return string.Format("users"  );
        }
        ///<summary>
        /// /user/emails
        ///</summary>
        public static string UserEmails(  )
        {
        		return string.Format("user/emails"  );
        }
        ///<summary>
        /// /users/:user/followers
        ///</summary>
        public static string UsersUserFollowers( string @user )
        {
        		Contract.Requires( @user!=null );
        		return string.Format("users/{0}/followers" ,@user );
        }
        ///<summary>
        /// /user/followers
        ///</summary>
        public static string UserFollowers(  )
        {
        		return string.Format("user/followers"  );
        }
        ///<summary>
        /// /users/:user/following
        ///</summary>
        public static string UsersUserFollowing( string @user )
        {
        		Contract.Requires( @user!=null );
        		return string.Format("users/{0}/following" ,@user );
        }
        ///<summary>
        /// /user/following
        ///</summary>
        public static string UserFollowing(  )
        {
        		return string.Format("user/following"  );
        }
        ///<summary>
        /// /user/following/:user
        ///</summary>
        public static string UserFollowingUser( string @user )
        {
        		Contract.Requires( @user!=null );
        		return string.Format("user/following/{0}" ,@user );
        }
        ///<summary>
        /// /users/:user/following/:target_user
        ///</summary>
        public static string UsersUserFollowingTarget_user( string @user, string @target_user )
        {
        		Contract.Requires( @user!=null );
        		Contract.Requires( @target_user!=null );
        		return string.Format("users/{0}/following/{1}" ,@user, @target_user );
        }
        ///<summary>
        /// /users/:user/keys
        ///</summary>
        public static string UsersUserKeys( string @user )
        {
        		Contract.Requires( @user!=null );
        		return string.Format("users/{0}/keys" ,@user );
        }
        ///<summary>
        /// /user/keys
        ///</summary>
        public static string UserKeys(  )
        {
        		return string.Format("user/keys"  );
        }
        ///<summary>
        /// /user/keys/:id
        ///</summary>
        public static string UserKeysId( string @id )
        {
        		Contract.Requires( @id!=null );
        		return string.Format("user/keys/{0}" ,@id );
        }
        ///<summary>
        /// /legacy/issues/search/:owner/:repository/:state/:keyword
        ///</summary>
        public static string LegacyIssuesSearchOwnerRepositoryStateKeyword( string @owner, string @repository, string @state, string @keyword )
        {
        		Contract.Requires( @owner!=null );
        		Contract.Requires( @repository!=null );
        		Contract.Requires( @state!=null );
        		Contract.Requires( @keyword!=null );
        		return string.Format("legacy/issues/search/{0}/{1}/{2}/{3}" ,@owner, @repository, @state, @keyword );
        }
        ///<summary>
        /// /legacy/repos/search/:keyword
        ///</summary>
        public static string LegacyReposSearchKeyword( string @keyword )
        {
        		Contract.Requires( @keyword!=null );
        		return string.Format("legacy/repos/search/{0}" ,@keyword );
        }
        ///<summary>
        /// /legacy/user/search/:keyword
        ///</summary>
        public static string LegacyUserSearchKeyword( string @keyword )
        {
        		Contract.Requires( @keyword!=null );
        		return string.Format("legacy/user/search/{0}" ,@keyword );
        }
        ///<summary>
        /// /legacy/user/email/:email
        ///</summary>
        public static string LegacyUserEmailEmail( string @email )
        {
        		Contract.Requires( @email!=null );
        		return string.Format("legacy/user/email/{0}" ,@email );
        }
        ///<summary>
        /// /gitignore/templates
        ///</summary>
        public static string GitignoreTemplates(  )
        {
        		return string.Format("gitignore/templates"  );
        }
        ///<summary>
        /// /gitignore/templates/:name
        ///</summary>
        public static string GitignoreTemplatesName( string @name )
        {
        		Contract.Requires( @name!=null );
        		return string.Format("gitignore/templates/{0}" ,@name );
        }
        ///<summary>
        /// /markdown
        ///</summary>
        public static string Markdown(  )
        {
        		return string.Format("markdown"  );
        }
        ///<summary>
        /// /markdown/raw
        ///</summary>
        public static string MarkdownRaw(  )
        {
        		return string.Format("markdown/raw"  );
        }
	}
}

