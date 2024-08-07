# Bulk Exe Firewall Blocker

A simple app for adding a block rule into Windows Firewall rules for multiple .exe files within a directory. 

### [Get the Latest Release](https://github.com/edgarbarney/BulkExeFirewallBlocker/releases/latest)

This can also be accomplished with batch scripts. But for non-programmers; if Windows updates break workflow, they may not be able to use or modify the script.
This app makes the process easier.

```bat
@setlocal enableextensions
@cd /d "%~dp0"

for /R %%f in (*.exe) do (
netsh advfirewall firewall add rule name="Blocked: %%f" dir=in program="%%f" action=block
netsh advfirewall firewall add rule name="Blocked: %%f" dir=out program="%%f" action=block
)

pause
```
