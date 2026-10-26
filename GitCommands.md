# Git: Checklist by Case

> Replace the texts in `<angle brackets>` with the real values (without the `< >` symbols).

---

## 1. Push a new project to GitHub

1. Initialize the repo: `git init`
2. Add files: `git add .`
3. First commit: `git commit -m "First commit"`
4. Rename the branch to main: `git branch -M main`
5. Connect to GitHub: `git remote add origin <URL>`
6. Push: `git push -u origin main`

---

## 2. My GitHub username/remote URL changed

1. Change the URL: `git remote set-url origin <NEW_URL>`
2. Verify: `git remote -v`

---

## 3. Start a new task (new branch)

1. Go to main: `git switch main`
2. Get the latest changes: `git pull`
3. Create and enter the branch: `git switch -c <branch-name>`

> One new branch per task. Use a descriptive name: `fix-database`, `add-grades-section`...

---

## 4. Day-to-day work on my branch

1. See what changed: `git status`
2. Add specific files: `git add <file>`
3. Commit: `git commit -m "#<issue-number> description"`
4. Push the branch (first time): `git push -u origin <branch-name>`
5. Push the branch (later times): `git push`

> `push` from your branch **does not touch main**. It is a backup and makes your work visible.
> Commit format to link with an issue: `#4 message`.

---

## 5. One commit per file (separating changes)

1. `git status`
2. `git add <file_a>`
3. `git commit -m "#<issue-number> changes in A"`
4. `git add <file_b>`
5. `git commit -m "#<issue-number> changes in B"`

Extras:

- Remove a file from staging without losing changes: `git restore --staged <file>`
- Split changes within the same file: `git add -p <file>`
- In VS Code: Source Control tab, `+` button next to each file.

---

## 6. Task finished: merge into main

1. Commit everything pending
2. `git switch main`
3. `git pull`
4. `git switch <branch-name>`
5. Bring main into my branch: `git merge main`
6. Resolve conflicts if any (see section 9)
7. Push my branch: `git push -u origin <branch-name>`
8. Then choose one:
   - **Option A, Pull Request:** open a PR on GitHub, get it reviewed, merge from the web
   - **Option B, direct merge:**
     1. `git switch main`
     2. `git merge <branch-name>`
     3. `git push`
9. Delete the local branch: `git branch -d <branch-name>`
10. Delete the remote branch (optional): `git push origin --delete <branch-name>`

---

## 7. Urgent: push only some files to main (cherry-pick)

Case: I have changes in A, B, C, D (uncommitted) and only C and D must go to main now.

1. Commit only C and D: `git add <file_c> <file_d>`
2. `git commit -m "#<issue-number> update database"`
3. Get the hash: `git log --oneline -1` (example: `a1b2c3d`)
4. Set A and B aside: `git stash`
5. `git switch main`
6. `git pull`
7. Copy the commit: `git cherry-pick <hash>`
8. `git push`
9. Go back to my branch: `git switch <branch-name>`
10. Recover A and B: `git stash pop`

If the cherry-pick has a conflict:

- Resolve it, then `git add <file>` and `git cherry-pick --continue`
- Cancel: `git cherry-pick --abort`

> If your team doesn't allow direct pushes to main: create a branch from main (`git switch -c hotfix-db`), cherry-pick there, push it and open a PR.

---

## 8. Recover a file as it is in main

1. `git restore --source=main -- <path/to/file>`
2. Delete the copy left in the wrong place
3. `git status` to check
4. Commit

> `merge main` does **not** fix a file you moved yourself: it only brings what changed in main.

---

## 9. Merge conflicts

1. `git status` (lists the conflicting files)
2. Open each file and look for the markers:

```
<<<<<<< HEAD
your version
=======
the other branch's version
>>>>>>> other-branch
```

3. Keep the final code and delete the markers
4. `git add <file>`
5. `git commit` (completes the merge)

Cancel the merge if something goes wrong: `git merge --abort`

---

## 10. Fixing common mistakes

| Problem | What to do |
|---|---|
| `src refspec ... does not match any` | Check the exact name with `git branch` and that there is at least one commit (`git log --oneline`) |
| I added something extra to staging | `git restore --staged <file>` |
| I want to discard uncommitted changes in a file | `git restore <file>` (**irreversible**) |
| I don't know which branch I'm on | `git branch` (the one with `*`) |
| Switching branches with uncommitted changes | Commit or `git stash` first |

---

## 11. Stash (temporarily save changes)

1. Save: `git stash`
2. See the list: `git stash list`
3. Recover and remove from the list: `git stash pop`

---

## 12. Change messages of existing commits

**Only the last commit, if not pushed yet:**

1. `git commit --amend -m "#<issue-number> new message"`

**Several commits already pushed (rewrites history, be careful on a shared main!):**

1. Preferred: comment the hashes on the issue (`a1b2c3d`) instead of rewriting
2. If agreed with the team: `git rebase -i HEAD~<N>`
3. Change `pick` to `reword` on the commits to edit
4. Edit each message
5. `git push --force-with-lease`

---

## 13. Useful lookup commands

| Command | What it does |
|---|---|
| `git status` | Current state of files |
| `git branch` | List local branches |
| `git branch -a` | List local and remote branches |
| `git log --oneline` | Short history |
| `git log --oneline --graph --all` | History shown as a branch graph |
| `git show --stat <hash>` | Which files a commit touched |
| `git diff` | Changes not yet staged |
| `git remote -v` | Remote URL |