# **Trying out the built-in container support for the .NET 7 SDK**

A few months ago, the built-in container support for the .NET SDK was announced.   
This feature allows us to containerize our application using the ``dotnet publish`` command, with no need of having to write a  ``Dockerfile``.

I've been wanting to try this new feature for quite a while, but I don't want to use it with a simple "Hello World" .NET app, because I know that it will work well with it.    
Instead, **I decided that I'll try to migrate an app that has a rather "complex" ``Dockerfile`` to a new version that has no ``Dockerfile`` and instead uses the built-in container support feature**.

# **Repository Content**

The repository contains:

- A .NET 7 BookStore API.
- A ``Dockerfile``. 
  - This ``Dockerfile`` will be the starting point from where to migrate to a "dockerfile-less" app that uses the container support for .NET 7 SDK.
  - You can take a look at the end result on the ``src/BookStore.WebApi/BookStore.WebApi.csproj`` file.
- An ``azure-pipelines.yml`` file.
  - It shows how to build a CI/CD pipeline that uses the container support for .NET SDK to create an image and deploy it into a private ``AWS ECR`` repository.

# **How to run it**

> **Important**: **You WON'T be able to execute the app from this repository and neither to build a container using the Dockerfile.**

### **Why is that?**

I didn't want to try this feature with a dummy app that uses a simple ``Dockerfile``, instead of that I tried to emulate a more realistic line of business .NET application with a more complex ``Dockerfile``.

**What that really means?**

One of the things I wanted to test is how the .NET SDK container support works when the app needs some private resources, that's why you won't be able to execute the API because the app and the Dockerfile contains a few private references.

To be more precise:
- The app references a few private packages hosted on my private ``Azure DevOps`` feed.
- The ``Dockerfile`` uses a 2 private images as base images. Those images are hosted on my private ``AWS ECR`` repository. 

### **What can I do with this repository?**

Not much, this repository is for support of my blog post.
- Here's the link to my post: NOT-AVAILABLE-YET.
