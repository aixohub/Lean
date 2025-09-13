FROM aixohub/lean-base:latest


COPY ./Data/  /Lean/Data/
COPY ./Launcher/bin/Debug/  /Lean/Launcher/bin/Debug/
COPY ./Optimizer.Launcher/bin/Debug/  /Lean/Optimizer.Launcher/bin/Debug/
COPY ./Report/bin/Debug/  /Lean/Report/bin/Debug/
COPY ./DownloaderDataProvider/bin/Debug/  /Lean/DownloaderDataProvider/bin/Debug/

RUN chown -R work:work  /Lean
# Can override with '-w'
WORKDIR /Lean/Launcher/bin/Debug

ENTRYPOINT [ "dotnet", "QuantConnect.Lean.Launcher.dll" ]
