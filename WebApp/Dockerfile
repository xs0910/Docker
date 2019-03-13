FROM microsoft/dotnet:2.2-aspnetcore-runtime
LABEL version = "1.0"
RUN mkdir /data
COPY ./ /data
WORKDIR /data
VOLUME /data/log
EXPOSE 8080
CMD [ "dotnet","WebApp.dll" ]