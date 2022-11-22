# **Trying out the built-in container support for the .NET 7 SDK**

A few months ago the built-in container support in the .NET 7 SDK was announced.
This feature allows us to create containerized versions of our applications just using the ``dotnet publish`` command and without the need of having a Dockerfile. 

I don't want to try this feature with a "Hello World" .NET app, I know that it works well with it, instead let's try it with a more realistic .NET line of business application that uses a more complex ``Dockerfile`` and see how it performs.

# **Repository Content**

The repository contains:

- A .NET 7 BookStore API.
- A ``Dockerfile``. 
  - This ``Dockerfile`` will be the starting point from where to migrate to a "docker-less" app that uses the container support for .NET 7 SDK instead of the ``Dockerfile``.
  - You can take a look at the end result on the ``src/BookStore.WebApi/BookStore.WebApi.csproj`` file.
- An ``azure-pipelines.yml`` file that shows how to build a CI/CD pipeline that can create a container image and deploy it into a private ``AWS ECR`` repository using the container support for .NET 7 SDK.

# **How to run it**

> **Important**: **You WON'T be able to execute the api and neither to build a container using the Dockerfile.**

### **Why is that?**

I didn't want to try the container support feature with a simple app that uses a simple ``Dockerfile``, instead of that I tried to emulate a more realistic line of business .NET application with a more complex ``Dockerfile``.

**And what that really means?**

One of the things I wanted to test is how the container support feature works when the app uses some private resources, that's why you won't be able to execute it, because the app and the Dockerfile contains a few private resources.

To be more precise:

- The app has a few references to private packages hosted on my private Azure DevOps feed.

- The ``Dockerfile`` uses a pair of private images as base images. Those images are hosted on my private ECR repository.
Using a platform image instead of using directly the public Microsoft images is a good security practice and also quite common in the enterprise.

### **What can I do with this repository?**

Not much, this repository is for support of my blog post.
- Here's the link to my post: NOT-AVAILABLE-YET.
