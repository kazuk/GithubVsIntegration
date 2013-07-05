﻿
// ReSharper disable CheckNamespace
namespace GithubClient.Models 
{
// ReSharper disable InconsistentNaming

/**** Authorization

{
 "id":2972767,
 "url":"https://api.github.com/authorizations/2972767",
 "app":
{
  "name":"admin script (API)",
  "url":"http://developer.github.com/v3/oauth/#oauth-authorizations-api",
  "client_id":"いやん"
 },
 "token":"みちゃいや",
 "note":"admin script",
 "note_url":null,
 "created_at":"2013-07-03T22:13:22Z",
 "updated_at":"2013-07-03T22:13:22Z",
 "scopes":["public_repo"]
}
*/
/**** Repository
	omit
*/
/**** CreateRepositoryResult

{
  "id": 1296269,
  "owner": 
{
    "login": "octocat",
    "id": 1,
    "avatar_url": "https://github.com/images/error/octocat_happy.gif",
    "gravatar_id": "somehexcode",
    "url": "https://api.github.com/users/octocat"
  },
  "name": "Hello-World",
  "full_name": "octocat/Hello-World",
  "description": "This your first repo!",
  "private": false,
  "fork": false,
  "url": "https://api.github.com/repos/octocat/Hello-World",
  "html_url": "https://github.com/octocat/Hello-World",
  "clone_url": "https://github.com/octocat/Hello-World.git",
  "git_url": "git://github.com/octocat/Hello-World.git",
  "ssh_url": "git@github.com:octocat/Hello-World.git",
  "svn_url": "https://svn.github.com/octocat/Hello-World",
  "mirror_url": "git://git.example.com/octocat/Hello-World",
  "homepage": "https://github.com",
  "language": null,
  "forks": 9,
  "forks_count": 9,
  "watchers": 80,
  "watchers_count": 80,
  "size": 108,
  "master_branch": "master",
  "open_issues": 0,
  "pushed_at": "2011-01-26T19:06:43Z",
  "created_at": "2011-01-26T19:01:12Z",
  "updated_at": "2011-01-26T19:14:43Z"
}
*/
/**** Collaborator
  
{
    "login": "octocat",
    "id": 1,
    "avatar_url": "https://github.com/images/error/octocat_happy.gif",
    "gravatar_id": "somehexcode",
    "url": "https://api.github.com/users/octocat"
  }
*/
/**** Comment
  
{
    "html_url": "https://github.com/octocat/Hello-World/commit/6dcb09b5b57875f334f61aebed695e2e4193db5e#commitcomment-1",
    "url": "https://api.github.com/repos/octocat/Hello-World/comments/1",
    "id": 1,
    "body": "Great stuff",
    "path": "file1.txt",
    "position": 4,
    "line": 14,
    "commit_id": "6dcb09b5b57875f334f61aebed695e2e4193db5e",
    "user": 
{
      "login": "octocat",
      "id": 1,
      "avatar_url": "https://github.com/images/error/octocat_happy.gif",
      "gravatar_id": "somehexcode",
      "url": "https://api.github.com/users/octocat"
    },
    "created_at": "2011-04-14T16:00:49Z",
    "updated_at": "2011-04-14T16:00:49Z"
  }
*/
/**** Issue
  
{
    "url": "https://api.github.com/repos/octocat/Hello-World/issues/1347",
    "html_url": "https://github.com/octocat/Hello-World/issues/1347",
    "number": 1347,
    "state": "open",
    "title": "Found a bug",
    "body": "I'm having a problem with this.",
    "user": 
{
      "login": "octocat",
      "id": 1,
      "avatar_url": "https://github.com/images/error/octocat_happy.gif",
      "gravatar_id": "somehexcode",
      "url": "https://api.github.com/users/octocat"
    },
    "labels": [
      
{
        "url": "https://api.github.com/repos/octocat/Hello-World/labels/bug",
        "name": "bug",
        "color": "f29513"
      }
    ],
    "assignee": 
{
      "login": "octocat",
      "id": 1,
      "avatar_url": "https://github.com/images/error/octocat_happy.gif",
      "gravatar_id": "somehexcode",
      "url": "https://api.github.com/users/octocat"
    },
    "milestone": 
{
      "url": "https://api.github.com/repos/octocat/Hello-World/milestones/1",
      "number": 1,
      "state": "open",
      "title": "v1.0",
      "description": "",
      "creator": 
{
        "login": "octocat",
        "id": 1,
        "avatar_url": "https://github.com/images/error/octocat_happy.gif",
        "gravatar_id": "somehexcode",
        "url": "https://api.github.com/users/octocat"
      },
      "open_issues": 4,
      "closed_issues": 8,
      "created_at": "2011-04-10T20:09:31Z",
      "due_on": null
    },
    "comments": 0,
    "pull_request": 
{
      "html_url": "https://github.com/octocat/Hello-World/issues/1347",
      "diff_url": "https://github.com/octocat/Hello-World/issues/1347.diff",
      "patch_url": "https://github.com/octocat/Hello-World/issues/1347.patch"
    },
    "closed_at": null,
    "created_at": "2011-04-22T13:33:48Z",
    "updated_at": "2011-04-22T13:33:48Z"
  }
*/

    public class Authorization
    {
    	public double @id { get; set; }
    	public string @url { get; set; }
    	public TempClass0001 @app { get; set; }
    	public string @token { get; set; }
    	public string @note { get; set; }
    	public object @note_url { get; set; }
    	public string @created_at { get; set; }
    	public string @updated_at { get; set; }
    	public string[] @scopes { get; set; }
    }
    public class Repository
    {
    	public double @id { get; set; }
    	public string @name { get; set; }
    	public string @full_name { get; set; }
    	public TempClass0002 @owner { get; set; }
    	public bool @private { get; set; }
    	public string @html_url { get; set; }
    	public object @description { get; set; }
    	public bool @fork { get; set; }
    	public string @url { get; set; }
    	public string @forks_url { get; set; }
    	public string @keys_url { get; set; }
    	public string @collaborators_url { get; set; }
    	public string @teams_url { get; set; }
    	public string @hooks_url { get; set; }
    	public string @issue_events_url { get; set; }
    	public string @events_url { get; set; }
    	public string @assignees_url { get; set; }
    	public string @branches_url { get; set; }
    	public string @tags_url { get; set; }
    	public string @blobs_url { get; set; }
    	public string @git_tags_url { get; set; }
    	public string @git_refs_url { get; set; }
    	public string @trees_url { get; set; }
    	public string @statuses_url { get; set; }
    	public string @languages_url { get; set; }
    	public string @stargazers_url { get; set; }
    	public string @contributors_url { get; set; }
    	public string @subscribers_url { get; set; }
    	public string @subscription_url { get; set; }
    	public string @commits_url { get; set; }
    	public string @git_commits_url { get; set; }
    	public string @comments_url { get; set; }
    	public string @issue_comment_url { get; set; }
    	public string @contents_url { get; set; }
    	public string @compare_url { get; set; }
    	public string @merges_url { get; set; }
    	public string @archive_url { get; set; }
    	public string @downloads_url { get; set; }
    	public string @issues_url { get; set; }
    	public string @pulls_url { get; set; }
    	public string @milestones_url { get; set; }
    	public string @notifications_url { get; set; }
    	public string @labels_url { get; set; }
    	public string @created_at { get; set; }
    	public string @updated_at { get; set; }
    	public string @pushed_at { get; set; }
    	public string @git_url { get; set; }
    	public string @ssh_url { get; set; }
    	public string @clone_url { get; set; }
    	public string @svn_url { get; set; }
    	public object @homepage { get; set; }
    	public double @size { get; set; }
    	public double @watchers_count { get; set; }
    	public string @language { get; set; }
    	public bool @has_issues { get; set; }
    	public bool @has_downloads { get; set; }
    	public bool @has_wiki { get; set; }
    	public double @forks_count { get; set; }
    	public object @mirror_url { get; set; }
    	public double @open_issues_count { get; set; }
    	public double @forks { get; set; }
    	public double @open_issues { get; set; }
    	public double @watchers { get; set; }
    	public string @master_branch { get; set; }
    	public string @default_branch { get; set; }
    	public TempClass0003 @permissions { get; set; }
    }
    public class CreateRepositoryResult
    {
    	public double @id { get; set; }
    	public TempClass0002 @owner { get; set; }
    	public string @name { get; set; }
    	public string @full_name { get; set; }
    	public string @description { get; set; }
    	public bool @private { get; set; }
    	public bool @fork { get; set; }
    	public string @url { get; set; }
    	public string @html_url { get; set; }
    	public string @clone_url { get; set; }
    	public string @git_url { get; set; }
    	public string @ssh_url { get; set; }
    	public string @svn_url { get; set; }
    	public string @mirror_url { get; set; }
    	public string @homepage { get; set; }
    	public object @language { get; set; }
    	public double @forks { get; set; }
    	public double @forks_count { get; set; }
    	public double @watchers { get; set; }
    	public double @watchers_count { get; set; }
    	public double @size { get; set; }
    	public string @master_branch { get; set; }
    	public double @open_issues { get; set; }
    	public string @pushed_at { get; set; }
    	public string @created_at { get; set; }
    	public string @updated_at { get; set; }
    }
    public class Collaborator
    {
    	public string @login { get; set; }
    	public double @id { get; set; }
    	public string @avatar_url { get; set; }
    	public string @gravatar_id { get; set; }
    	public string @url { get; set; }
    }
    public class Comment
    {
    	public string @html_url { get; set; }
    	public string @url { get; set; }
    	public double @id { get; set; }
    	public string @body { get; set; }
    	public string @path { get; set; }
    	public double @position { get; set; }
    	public double @line { get; set; }
    	public string @commit_id { get; set; }
    	public Collaborator @user { get; set; }
    	public string @created_at { get; set; }
    	public string @updated_at { get; set; }
    }
    public class Issue
    {
    	public string @url { get; set; }
    	public string @html_url { get; set; }
    	public double @number { get; set; }
    	public string @state { get; set; }
    	public string @title { get; set; }
    	public string @body { get; set; }
    	public Collaborator @user { get; set; }
    	public TempClass0004[] @labels { get; set; }
    	public Collaborator @assignee { get; set; }
    	public TempClass0005 @milestone { get; set; }
    	public double @comments { get; set; }
    	public TempClass0006 @pull_request { get; set; }
    	public object @closed_at { get; set; }
    	public string @created_at { get; set; }
    	public string @updated_at { get; set; }
    }
    public class TempClass0001
    {
    	public string @name { get; set; }
    	public string @url { get; set; }
    	public string @client_id { get; set; }
    }
    public class TempClass0002
    {
    	public string @login { get; set; }
    	public double @id { get; set; }
    	public string @avatar_url { get; set; }
    	public string @gravatar_id { get; set; }
    	public string @url { get; set; }
    	public string @html_url { get; set; }
    	public string @followers_url { get; set; }
    	public string @following_url { get; set; }
    	public string @gists_url { get; set; }
    	public string @starred_url { get; set; }
    	public string @subscriptions_url { get; set; }
    	public string @organizations_url { get; set; }
    	public string @repos_url { get; set; }
    	public string @events_url { get; set; }
    	public string @received_events_url { get; set; }
    	public string @type { get; set; }
    }
    public class TempClass0003
    {
    	public bool @admin { get; set; }
    	public bool @push { get; set; }
    	public bool @pull { get; set; }
    }
    public class TempClass0004
    {
    	public string @url { get; set; }
    	public string @name { get; set; }
    	public string @color { get; set; }
    }
    public class TempClass0005
    {
    	public string @url { get; set; }
    	public double @number { get; set; }
    	public string @state { get; set; }
    	public string @title { get; set; }
    	public string @description { get; set; }
    	public Collaborator @creator { get; set; }
    	public double @open_issues { get; set; }
    	public double @closed_issues { get; set; }
    	public string @created_at { get; set; }
    	public object @due_on { get; set; }
    }
    public class TempClass0006
    {
    	public string @html_url { get; set; }
    	public string @diff_url { get; set; }
    	public string @patch_url { get; set; }
    }
}
