
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
/**** DeployKey
  
{
    "id": 1,
    "key": "ssh-rsa AAA...",
    "url": "https://api.github.com/user/keys/1",
    "title": "octocat@octomac"
  }
*/
/**** Hook

{
  "name": "web",
  "active": true,
  "events": [
    "push",
    "pull_request"
  ],
  "config": 
{
    "url": "http://example.com/webhook",
    "content_type": "json"
  }
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
/**** Commit

{
  "url": "https://api.github.com/repos/octocat/Hello-World/commits/6dcb09b5b57875f334f61aebed695e2e4193db5e",
  "sha": "6dcb09b5b57875f334f61aebed695e2e4193db5e",
  "commit": 
{
    "url": "https://api.github.com/repos/octocat/Hello-World/git/commits/6dcb09b5b57875f334f61aebed695e2e4193db5e",
    "author": 
{
      "name": "Monalisa Octocat",
      "email": "support@github.com",
      "date": "2011-04-14T16:00:49Z"
    },
    "committer": 
{
      "name": "Monalisa Octocat",
      "email": "support@github.com",
      "date": "2011-04-14T16:00:49Z"
    },
    "message": "Fix all the bugs",
    "tree": 
{
      "url": "https://api.github.com/repos/octocat/Hello-World/tree/6dcb09b5b57875f334f61aebed695e2e4193db5e",
      "sha": "6dcb09b5b57875f334f61aebed695e2e4193db5e"
    }
  },
  "author": 
{
    "login": "octocat",
    "id": 1,
    "avatar_url": "https://github.com/images/error/octocat_happy.gif",
    "gravatar_id": "somehexcode",
    "url": "https://api.github.com/users/octocat"
  },
  "committer": 
{
    "login": "octocat",
    "id": 1,
    "avatar_url": "https://github.com/images/error/octocat_happy.gif",
    "gravatar_id": "somehexcode",
    "url": "https://api.github.com/users/octocat"
  },
  "parents": [
    
{
      "url": "https://api.github.com/repos/octocat/Hello-World/commits/6dcb09b5b57875f334f61aebed695e2e4193db5e",
      "sha": "6dcb09b5b57875f334f61aebed695e2e4193db5e"
    }
  ],
  "stats": 
{
    "additions": 104,
    "deletions": 4,
    "total": 108
  },
  "files": [
    
{
      "filename": "file1.txt",
      "additions": 10,
      "deletions": 2,
      "changes": 12,
      "status": "modified",
      "raw_url": "https://github.com/octocat/Hello-World/raw/7ca483543807a51b6079e54ac4cc392bc29ae284/file1.txt",
      "blob_url": "https://github.com/octocat/Hello-World/blob/7ca483543807a51b6079e54ac4cc392bc29ae284/file1.txt",
      "patch": "@@ -29,7 +29,7 @@\n....."
    }
  ]
}
*/
/**** CompareCommitResult

{
  "url": "https://api.github.com/repos/octocat/Hello-World/compare/master...topic",
  "html_url": "https://github.com/octocat/Hello-World/compare/master...topic",
  "permalink_url": "https://github.com/octocat/Hello-World/compare/octocat:bbcd538c8e72b8c175046e27cc8f907076331401...octocat:0328041d1152db8ae77652d1618a02e57f745f17",
  "diff_url": "https://github.com/octocat/Hello-World/compare/master...topic.diff",
  "patch_url": "https://github.com/octocat/Hello-World/compare/master...topic.patch",
  "base_commit": 
{
    "url": "https://api.github.com/repos/octocat/Hello-World/commits/6dcb09b5b57875f334f61aebed695e2e4193db5e",
    "sha": "6dcb09b5b57875f334f61aebed695e2e4193db5e",
    "commit": 
{
      "url": "https://api.github.com/repos/octocat/Hello-World/git/commits/6dcb09b5b57875f334f61aebed695e2e4193db5e",
      "author": 
{
        "name": "Monalisa Octocat",
        "email": "support@github.com",
        "date": "2011-04-14T16:00:49Z"
      },
      "committer": 
{
        "name": "Monalisa Octocat",
        "email": "support@github.com",
        "date": "2011-04-14T16:00:49Z"
      },
      "message": "Fix all the bugs",
      "tree": 
{
        "url": "https://api.github.com/repos/octocat/Hello-World/tree/6dcb09b5b57875f334f61aebed695e2e4193db5e",
        "sha": "6dcb09b5b57875f334f61aebed695e2e4193db5e"
      }
    },
    "author": 
{
      "login": "octocat",
      "id": 1,
      "avatar_url": "https://github.com/images/error/octocat_happy.gif",
      "gravatar_id": "somehexcode",
      "url": "https://api.github.com/users/octocat"
    },
    "committer": 
{
      "login": "octocat",
      "id": 1,
      "avatar_url": "https://github.com/images/error/octocat_happy.gif",
      "gravatar_id": "somehexcode",
      "url": "https://api.github.com/users/octocat"
    },
    "parents": [
      
{
        "url": "https://api.github.com/repos/octocat/Hello-World/commits/6dcb09b5b57875f334f61aebed695e2e4193db5e",
        "sha": "6dcb09b5b57875f334f61aebed695e2e4193db5e"
      }
    ]
  },
  "status": "behind",
  "ahead_by": 1,
  "behind_by": 2,
  "total_commits": 1,
  "commits": [
    
{
      "url": "https://api.github.com/repos/octocat/Hello-World/commits/6dcb09b5b57875f334f61aebed695e2e4193db5e",
      "sha": "6dcb09b5b57875f334f61aebed695e2e4193db5e",
      "commit": 
{
        "url": "https://api.github.com/repos/octocat/Hello-World/git/commits/6dcb09b5b57875f334f61aebed695e2e4193db5e",
        "author": 
{
          "name": "Monalisa Octocat",
          "email": "support@github.com",
          "date": "2011-04-14T16:00:49Z"
        },
        "committer": 
{
          "name": "Monalisa Octocat",
          "email": "support@github.com",
          "date": "2011-04-14T16:00:49Z"
        },
        "message": "Fix all the bugs",
        "tree": 
{
          "url": "https://api.github.com/repos/octocat/Hello-World/tree/6dcb09b5b57875f334f61aebed695e2e4193db5e",
          "sha": "6dcb09b5b57875f334f61aebed695e2e4193db5e"
        }
      },
      "author": 
{
        "login": "octocat",
        "id": 1,
        "avatar_url": "https://github.com/images/error/octocat_happy.gif",
        "gravatar_id": "somehexcode",
        "url": "https://api.github.com/users/octocat"
      },
      "committer": 
{
        "login": "octocat",
        "id": 1,
        "avatar_url": "https://github.com/images/error/octocat_happy.gif",
        "gravatar_id": "somehexcode",
        "url": "https://api.github.com/users/octocat"
      },
      "parents": [
        
{
          "url": "https://api.github.com/repos/octocat/Hello-World/commits/6dcb09b5b57875f334f61aebed695e2e4193db5e",
          "sha": "6dcb09b5b57875f334f61aebed695e2e4193db5e"
        }
      ]
    }
  ],
  "files": [
    
{
      "sha": "6dcb09b5b57875f334f61aebed695e2e4193db5e",
      "filename": "file1.txt",
      "status": "added",
      "additions": 103,
      "deletions": 21,
      "changes": 124,
      "blob_url": "https://github.com/octocat/Hello-World/blob/6dcb09b5b57875f334f61aebed695e2e4193db5e/file1.txt",
      "raw_url": "https://github.com/octocat/Hello-World/raw/6dcb09b5b57875f334f61aebed695e2e4193db5e/file1.txt",
      "patch": "@@ -132,7 +132,7 @@ module Test @@ -1000,7 +1000,7 @@ module Test"
    }
  ]
}
*/
/**** Content

{
  "type": "file",
  "target": "/path/to/symlink/target",
  "submodule_git_url": "git://github.com/jquery/qunit.git",
  "encoding": "base64",
  "size": 5362,
  "name": "README.md",
  "path": "README.md",
  "content": "encoded content ...",
  "sha": "3d21ec53a331a6f037a91c368710b99387d012c1",
  "url": "https://api.github.com/repos/pengwynn/octokit/contents/README.md",
  "git_url": "https://api.github.com/repos/pengwynn/octokit/git/blobs/3d21ec53a331a6f037a91c368710b99387d012c1",
  "html_url": "https://github.com/pengwynn/octokit/blob/master/README.md",
  "_links": 
{
    "git": "https://api.github.com/repos/pengwynn/octokit/git/blobs/3d21ec53a331a6f037a91c368710b99387d012c1",
    "self": "https://api.github.com/repos/pengwynn/octokit/contents/README.md",
    "html": "https://github.com/pengwynn/octokit/blob/master/README.md"
  }
}
*/
/**** FileEditResult

{
  "content": 
{
    "name": "hello.txt",
    "path": "notes/hello.txt",
    "sha": "95b966ae1c166bd92f8ae7d1c313e738c731dfc3",
    "size": 9,
    "url": "https://api.github.com/repos/octocat/Hello-World/contents/notes/hello.txt",
    "html_url": "https://github.com/octocat/Hello-World/blob/master/notes/hello.txt",
    "git_url": "https://api.github.com/repos/octocat/Hello-World/git/blobs/95b966ae1c166bd92f8ae7d1c313e738c731dfc3",
    "type": "file",
    "_links": 
{
      "self": "https://api.github.com/repos/octocat/Hello-World/contents/notes/hello.txt",
      "git": "https://api.github.com/repos/octocat/Hello-World/git/blobs/95b966ae1c166bd92f8ae7d1c313e738c731dfc3",
      "html": "https://github.com/octocat/Hello-World/blob/master/notes/hello.txt"
    }
  },
  "commit": 
{
    "sha": "7638417db6d59f3c431d3e1f261cc637155684cd",
    "url": "https://api.github.com/repos/octocat/Hello-World/git/commits/7638417db6d59f3c431d3e1f261cc637155684cd",
    "html_url": "https://github.com/octocat/Hello-World/git/commit/7638417db6d59f3c431d3e1f261cc637155684cd",
    "author": 
{
      "date": "2010-04-10T14:10:01-07:00",
      "name": "Scott Chacon",
      "email": "schacon@gmail.com"
    },
    "committer": 
{
      "date": "2010-04-10T14:10:01-07:00",
      "name": "Scott Chacon",
      "email": "schacon@gmail.com"
    },
    "message": "my commit message",
    "tree": 
{
      "url": "https://api.github.com/repos/octocat/Hello-World/git/trees/691272480426f78a0138979dd3ce63b77f706feb",
      "sha": "691272480426f78a0138979dd3ce63b77f706feb"
    },
    "parents": [
      
{
        "url": "https://api.github.com/repos/octocat/Hello-World/git/commits/1acc419d4d6a9ce985db7be48c6349a0475975b5",
        "html_url": "https://github.com/octocat/Hello-World/git/commit/1acc419d4d6a9ce985db7be48c6349a0475975b5",
        "sha": "1acc419d4d6a9ce985db7be48c6349a0475975b5"
      }
    ]
  }
}
*/
/**** Download
  
{
    "url": "https://api.github.com/repos/octocat/Hello-World/downloads/1",
    "html_url": "https://github.com/repos/octocat/Hello-World/downloads/new_file.jpg",
    "id": 1,
    "name": "new_file.jpg",
    "description": "Description of your download",
    "size": 1024,
    "download_count": 40,
    "content_type": ".jpg"
  }
*/
/**** CreateDownloadResult

{
  "url": "https://api.github.com/repos/octocat/Hello-World/downloads/1",
  "html_url": "https://github.com/repos/octocat/Hello-World/downloads/new_file.jpg",
  "id": 1,
  "name": "new_file.jpg",
  "description": "Description of your download",
  "size": 1024,
  "download_count": 40,
  "content_type": ".jpg",
  "policy": "ewogICAg...",
  "signature": "mwnFDC...",
  "bucket": "github",
  "accesskeyid": "1ABCDEFG...",
  "path": "downloads/octocat/Hello-World/new_file.jpg",
  "acl": "public-read",
  "expirationdate": "2011-04-14T16:00:49Z",
  "prefix": "downloads/octocat/Hello-World/",
  "mime_type": "image/jpeg",
  "redirect": false,
  "s3_url": "https://github.s3.amazonaws.com/"
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
    	public Collaborator @owner { get; set; }
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
    public class DeployKey
    {
    	public double @id { get; set; }
    	public string @key { get; set; }
    	public string @url { get; set; }
    	public string @title { get; set; }
    }
    public class Hook
    {
    	public string @name { get; set; }
    	public bool @active { get; set; }
    	public string[] @events { get; set; }
    	public CreateDownloadResult @config { get; set; }
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
    public class Commit
    {
    	public string @url { get; set; }
    	public string @sha { get; set; }
    	public TempClass0014 @commit { get; set; }
    	public Collaborator @author { get; set; }
    	public Collaborator @committer { get; set; }
    	public Content[] @parents { get; set; }
    	public TempClass0008 @stats { get; set; }
    	public TempClass0012[] @files { get; set; }
    }
    public class CompareCommitResult
    {
    	public string @url { get; set; }
    	public string @html_url { get; set; }
    	public string @permalink_url { get; set; }
    	public string @diff_url { get; set; }
    	public string @patch_url { get; set; }
    	public Commit @base_commit { get; set; }
    	public string @status { get; set; }
    	public double @ahead_by { get; set; }
    	public double @behind_by { get; set; }
    	public double @total_commits { get; set; }
    	public Commit[] @commits { get; set; }
    	public TempClass0012[] @files { get; set; }
    }
    public class Content
    {
    	public string @type { get; set; }
    	public string @target { get; set; }
    	public string @submodule_git_url { get; set; }
    	public string @encoding { get; set; }
    	public double @size { get; set; }
    	public string @name { get; set; }
    	public string @path { get; set; }
    	public string @content { get; set; }
    	public string @sha { get; set; }
    	public string @url { get; set; }
    	public string @git_url { get; set; }
    	public string @html_url { get; set; }
    	public TempClass0013 @_links { get; set; }
    }
    public class FileEditResult
    {
    	public Content @content { get; set; }
    	public TempClass0014 @commit { get; set; }
    }
    public class Download
    {
    	public string @url { get; set; }
    	public string @html_url { get; set; }
    	public double @id { get; set; }
    	public string @name { get; set; }
    	public string @description { get; set; }
    	public double @size { get; set; }
    	public double @download_count { get; set; }
    	public string @content_type { get; set; }
    }
    public class CreateDownloadResult
    {
    	public string @url { get; set; }
    	public string @html_url { get; set; }
    	public double @id { get; set; }
    	public string @name { get; set; }
    	public string @description { get; set; }
    	public double @size { get; set; }
    	public double @download_count { get; set; }
    	public string @content_type { get; set; }
    	public string @policy { get; set; }
    	public string @signature { get; set; }
    	public string @bucket { get; set; }
    	public string @accesskeyid { get; set; }
    	public string @path { get; set; }
    	public string @acl { get; set; }
    	public string @expirationdate { get; set; }
    	public string @prefix { get; set; }
    	public string @mime_type { get; set; }
    	public bool @redirect { get; set; }
    	public string @s3_url { get; set; }
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
    	public TempClass0015[] @labels { get; set; }
    	public Collaborator @assignee { get; set; }
    	public TempClass0016 @milestone { get; set; }
    	public double @comments { get; set; }
    	public CompareCommitResult @pull_request { get; set; }
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
    public class TempClass0014
    {
    	public string @sha { get; set; }
    	public string @url { get; set; }
    	public string @html_url { get; set; }
    	public TempClass0006 @author { get; set; }
    	public TempClass0006 @committer { get; set; }
    	public string @message { get; set; }
    	public Content @tree { get; set; }
    	public Content[] @parents { get; set; }
    }
    public class TempClass0008
    {
    	public double @additions { get; set; }
    	public double @deletions { get; set; }
    	public double @total { get; set; }
    }
    public class TempClass0012
    {
    	public string @sha { get; set; }
    	public string @filename { get; set; }
    	public string @status { get; set; }
    	public double @additions { get; set; }
    	public double @deletions { get; set; }
    	public double @changes { get; set; }
    	public string @blob_url { get; set; }
    	public string @raw_url { get; set; }
    	public string @patch { get; set; }
    }
    public class TempClass0013
    {
    	public string @git { get; set; }
    	public string @self { get; set; }
    	public string @html { get; set; }
    }
    public class TempClass0015
    {
    	public string @url { get; set; }
    	public string @name { get; set; }
    	public string @color { get; set; }
    }
    public class TempClass0016
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
    	public string @name { get; set; }
    	public string @email { get; set; }
    	public string @date { get; set; }
    }
}
