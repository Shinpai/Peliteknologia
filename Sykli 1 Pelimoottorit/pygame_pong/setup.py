import cx_Freeze

executables = [cx_Freeze.Executable("pygame_pong.py")]

cx_Freeze.setup(
    name="pong",
    options={"build_exe": {"packages": "pygame"}},
    executables=executables
    )
