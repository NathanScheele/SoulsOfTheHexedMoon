# Souls of the Hexed Moon
A game made by Rift-Wolves, a group of MoonRift Entertainment interns.

***

### What you'll need to contribute to/run this project
- Clone this repo on your local machine.
  -`git clone https://github.com/NathanScheele/SoulsOfTheHexedMoon.git`

- Unity
  1. Download [Unity Hub](https://unity3d.com/get-unity/download).
  2. [Create Account?](https://id.unity.com/en/conversations/a7768f35-e174-4c14-b16be0670faa3f03003f)(I already have one, so I'm not sure if this is necessary).
  3. Install  Unity v2020.1.12f1 in Unity Hub.
  
- Code editor of your choice (VSCode is my personal go-to. Download Link --> [VSCode](https://code.visualstudio.com/))

***

### For those unfamiliar with Git
#### My quick explanation. Check out [GitHub Documentation](https://docs.github.com/en/free-pro-team@latest/github) for more detailed information.
- `git add <directory/file path>` : marks changed file(s) on your local machine as ready to be commited. Use this before you commit.
  - I usually use `git add .`, which marks all changes. Only use this if you're ready to commit ***everything***.
- `git commit -m "<commit message here>"` : commits all added changes to your local repo. If you commit something by mistake, don't worry, there are ways to go about [reverting](https://git-scm.com/docs/git-revert) and [resetting](https://git-scm.com/docs/git-reset) commits.
  - If you don't want to include the message on the command line, I believe you can configure git to open a text editor, where you can type the message.
- `git branch <new branch name>` : Creates a new branch with the specified name.
  - Branching is super helpful for maintaining clean version control and allowing multiple people to work on different parts of a project without deleting eachother's code.
- `git checkout <branch name>` : switches to the named branch.
  - Make sure to commit/discard any changes before switching.
- `git merge <branch name>` : merges the named branch with the current branch.
  - Watch out for merge conflicts! They're avoidable in some cases, but happen anyways. Not the end of the world :wink:
