const fs = require("fs");
module.exports = () => {
  const gitingnore = `${process.env.GITHUB_WORKSPACE}/.gitignore`;

  const answers = ["z*", ".env", "/artifacts/"];
  const contents = fs.readFileSync(gitingnore, "utf8").split("\n");
  try {
    const results = answers.filter((i) => {
      if (!contents.includes(i)) return i;
    });
    if (results.length === 0) {
      return {
        reports: [
          {
            filename: ".gitignore",
            isCorrect: true,
            display_type: "actions",
            level: "info",
            msg: "Great job!  You have sucessfully configured the .gitignore file for this repository",
            error: {
              expected: "",
              got: "",
            },
          },
        ],
      };
    } else {
      return {
        reports: [
          {
            filename: ".gitignore",
            isCorrect: false,
            display_type: "actions",
            level: "warning",
            msg: "Incorrect solution",
            error: {
              expected: ".env, /artifacts/, z* to exist in the .gitignore file",
              got: `You are missing ${results.join()}`,
            },
          },
        ],
      };
    }
  } catch (error) {
    return {
      reports: [
        {
          filename: ".gitignore",
          isCorrect: false,
          display_type: "actions",
          level: "fatal",
          msg: "Error",
          error: {
            expected: "",
            got: "An internal error occured.  Please open an issue at: https://github.com/githubtraining/exercise-use-gitignore and let us know!  Thank you",
          },
        },
      ],
    };
  }
};
