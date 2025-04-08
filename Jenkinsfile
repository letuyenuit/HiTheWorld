pipeline {
    agent any

    stages {
        stage('Hello') {
            steps {
                script {
                    // Kiểm tra nếu đây là một pull request
                    if (env.CHANGE_BRANCH) {
                        echo "Tên nhánh pull request: ${env.CHANGE_BRANCH}"
                    } else {
                        echo "Không phải pull request, nhánh hiện tại là: ${env.BRANCH_NAME}"
                    }
                }
            }
        }
    }
}
