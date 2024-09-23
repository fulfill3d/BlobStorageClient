
# BlobStorageClient

BlobStorageClient is a library for interacting with Azure Blob Storage. It provides functionalities to upload, download, and delete blobs, with support for various blob types and operations.

## Table of Contents

1. [Introduction](#introduction)
2. [Features](#features)
3. [Tech Stack](#tech-stack)
4. [Usage](#usage)
5. [Configuration](#configuration)

## Introduction

BlobStorageClient provides a simple and efficient way to interact with Azure Blob Storage, offering a set of APIs for blob management. It includes support for uploading files, downloading content, and deleting blobs, making it a versatile tool for handling storage operations.

## Features

- **Upload Blobs:** Upload files or data streams to Azure Blob Storage.
- **Download Blobs:** Retrieve blobs from Azure Blob Storage.
- **Delete Blobs:** Remove blobs from the storage account.

## Tech Stack

- **Backend:** .NET 8
- **Storage:** Azure Blob Storage
- **Dependency Injection:** Used for service registrations and configurations

## Usage

1. **Register the BlobStorageClient:** Use the `RegisterBlobStorageClient` extension method to register the client in the dependency injection container.
2. **Configure the options:** Set up `BlobStorageClientOptions` with the necessary configuration, including the connection string.
3. **Use the Client:** Use the `IBlobStorageClient` interface to interact with blobs, including uploading, downloading, and deleting.

## Configuration

### BlobStorageClientOptions

- **ConnectionString:** The connection string to the Azure Storage account.

```csharp
public class BlobStorageClientOptions
{
    public string ConnectionString { get; set; }
}
```
