// Guids.cs
// MUST match guids.h
using System;

namespace kazuk.GithubVs
{
    static class GuidList
    {
        public const string guidGithubVsPkgString = "8f534600-0534-4c45-b26a-9242fbd0e911";
        public const string guidGithubVsCmdSetString = "0f0d86fc-5262-4f65-a4f9-3b6b1c0b5c82";
        public const string guidToolWindowPersistanceString = "7d6807b0-e1ee-435c-a400-3550fc4f8d8b";

        public static readonly Guid guidGithubVsCmdSet = new Guid(guidGithubVsCmdSetString);
    };
}