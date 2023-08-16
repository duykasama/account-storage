pipeline {
    agent any

    stages{
        stage("Build"){
            steps{
                echo "========executing A========"
                sh 'dotnet restore'
                sh 'dotnet build --no-restore'
            }
            post{
                success{
                    echo "========A executed successfully========"
                    
                }
                failure{
                    echo "========A execution failed========"
                }
            }
        }

        stage("Publish"){
            steps{
                withDockerRegistry(credentialsId: 'docker-hub', url: 'https://index.docker.io/v1/'){
                    sh 'docker build -t duykasama/account-storage-image:built-by-jenkins .'
                    sh 'docker push duykasama/account-storage-image:built-by-jenkins'
                }
                
            }
        }
    }
    post{
        always{
            cleanup()
        }
    }
}