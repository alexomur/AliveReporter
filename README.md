# OUTDATED

# AliveReporter
EXILED SCP:SL Plugin which report at regular intervals about the presence of personnel, operators and SCPs in the facility.

# Pay attantion!
The plugin is currently under development. There may be bugs and errors. Please report to `Issues` if you find a problem.

# Config
```
AliveReporter:
  is_enabled: true
  debug: false
  # Should CASSIE report about this roles?
  report_dclass: true
  report_scientist: true
  report_guard: true
  report_ntf: true
  report_ci: true
  report_scp: true
  # Time interval between reports in seconds
  report_timer: 300
  # CASSIE report at the start of the round (May cause conflict if cassie is called by another plugin)
  report_on_start: true
  # Text that CASSIE will say. $Info$ - reporting message
  cassie_text: 'Personnel Report . . . <color=red> $Info$ </color> . . .'
```
