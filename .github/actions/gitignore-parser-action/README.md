# gitignore Parser Action

This local action runs whenever a change to the `.gitignore` file is pushed to your repository.

This action requires no additional inputs

## What checks does this action conduct?

- Reads the contents of the `.gitignore` file
- Attempts to compare the above contents against a desired answer set
- Reports the status of the comparison to the Looking Glass action in the `grading.yml` workflow
