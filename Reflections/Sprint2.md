# Sprint 2 Reflection

## Process Reflection

### Things that we didn’t do that we should have (START):
* Keep PRs small and use the “Merge and Squash” button on Github, so that the commit history corresponds to real changes, rather than tiny git fixes or typos.
* Communicate which files should be included in commits and when [In  regard to Visual Studio’s build files]
* Finish the majority of the coding sooner so we have more time to review style/maintainability.

### Things that we did that we shouldn’t have (STOP):
* I think we should try to keep branches small and constantly merge progress into master, so that we don’t have to do as many huge merges.
* With the number of branches we had and the differing times each person would commit, it would be better to constantly merge new files into the branches so that each branch has the most up-to-date code to help guarantee no issues will arise when that branch is ready to be pulled into master
* Committing Visual Studio Build files - We should be discarding any changes that are automatically built by Visual Studios with full paths prior to committing.

### Things that we did that were good (CONTINUE):
* Code reviews on GitHub seemed to work well.
* Discord was an effective communication channel.
* Trello task tracking was effective when used [utilized mostly towards end of Sprint].
* Everyone was able to attend the scheduled meetings.

## Code Relfection

### Constructive Code Changes (START/MORE)
* Link States and State Design Pattern
  * The Link State classes and their connection to the Player class are appropriately coupled and flexible to allow for future development.
## Detrimental Code Changes (STOP/AVOID)
* Sprint 2 Specific Code
  * Some classes or methods were designed with the limitations of Sprint 2 in mind. For much of Sprint 2, we only handled one of each enemy, NPC, obstacle, and player. The final game will need to handle multiples. This was changed toward the end, but is a good example of some of the design choices made in the project.
