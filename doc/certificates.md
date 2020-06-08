## Hosting an ASP.NET Core App on Docker with HTTPS

# Create and trust a .pfx certificate

We can create a certificate with the following command: `dotnet dev-certs https -ep [Path of the certificate]-p [Password]`. As an example we will create the certificate under "C:\temp" and set `SecretPassword` as its password.

```bash
 dotnet dev-certs https -v -ep c:\temp\cert-aspnetcore.pfx -p SecretPassword
  ```

Next, run the following command to install the ASP.NET Core HTTPS development certificate used by Kestrel:

 ```bash
 dotnet dev-certs https --trust
  ```

# Provide the Certificate to the Docker Image

After creating the certificate, we only have to share it with our container.

In the source code, we created and copied a sample certificate into the `Solution\CustomerApi\Infrastructure\Certificate\` project folder. This certificate is copied also into the container during the build. To do that we have to remove .pfx from the `.dockerignore` file.

Note that you should never share your certificate or put it inside a container. We only did it to simplify this demo. We should instead tell the Kestrel being executed in Docker where the certificate is located, and this should be done configuring the `C:\temp\` local path in Docker settings as a _bind mount_ (File sharing directory).

Then, we just need to use a volume parameter in the `docker run` command that allows us to share files from our computer with the container. We can use the following command:

 ```bash
docker run --name customerapi -p 32789:80 -p 32788:443 -e ASPNETCORE_HTTPS_PORT=32788 -e "ASPNETCORE_URLS=https://+;http://+" -e Kestrel__Certificates__Default__Path=/app/Infrastructure/Certificate/cert-aspnetcore.pfx -e Kestrel__Certificates__Default__Password=SecretPassword -v C:\temp\:/app/Infrastructure/Certificate jardotnet/customerapi
 ```
