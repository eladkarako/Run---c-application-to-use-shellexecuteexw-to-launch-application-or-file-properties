using System;
using System.Runtime.InteropServices;


namespace Run{
  class Program{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SHELLEXECUTEINFO{
      public uint cbSize;
      public uint fMask;
      public IntPtr hwnd;
      [MarshalAs(UnmanagedType.LPTStr)]
      public string lpVerb;
      [MarshalAs(UnmanagedType.LPTStr)]
      public string lpFile;
      [MarshalAs(UnmanagedType.LPTStr)]
      public string lpParameters;
      [MarshalAs(UnmanagedType.LPTStr)]
      public string lpDirectory;
      public int nShow;
      public IntPtr hInstApp;
      public IntPtr lpIDList;
      [MarshalAs(UnmanagedType.LPTStr)]
      public string lpClass;
      public IntPtr hkeyClass;
      public uint dwHotKey;
      public IntPtr hIconOrMonitor;
      public IntPtr hProcess;
    }

    [DllImport("shell32.dll", ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern bool ShellExecuteExW(ref SHELLEXECUTEINFO lpExecInfo);
    
    public static void Main(string[] args){
      
      SHELLEXECUTEINFO shell_execute_info = new SHELLEXECUTEINFO();
      shell_execute_info.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(shell_execute_info);
      //shell_execute_info.fMask = 0x0000000C | 0x00000100;                          // SEE_MASK_INVOKEIDLIST (0x0000000C) | SEE_MASK_NOASYNC (0x00000100)
      //shell_execute_info.fMask = 0x0000000C | 0x00100000;                          // SEE_MASK_INVOKEIDLIST (0x0000000C) | SEE_MASK_ASYNCOK (0x00100000)
      //shell_execute_info.fMask = 0x0000000C | 0x00100000 | 0x00004000;             // SEE_MASK_INVOKEIDLIST (0x0000000C) | SEE_MASK_ASYNCOK (0x00100000) | SEE_MASK_UNICODE (0x00004000) | SEE_MASK_NO_CONSOLE (0x00008000)
      //shell_execute_info.fMask = 0x0000000C | 0x00100000 | 0x00004000 | 0x00008000;  // SEE_MASK_INVOKEIDLIST (0x0000000C) | SEE_MASK_ASYNCOK (0x00100000) | SEE_MASK_UNICODE (0x00004000) | SEE_MASK_NO_CONSOLE (0x00008000)

      shell_execute_info.lpVerb = "Properties";
      shell_execute_info.lpFile = @"E:\Incoming\Alanis Morissette - Thank U.mp3"; // Path.Combine(PATH_PREFIX, filename);
      shell_execute_info.lpParameters = "Details";    //  null/"General"/"Security"/"Details"   --tab name (optional)
      shell_execute_info.nShow = 1;           // SW_SHOWNORMAL
      ShellExecuteExW(ref shell_execute_info);

      Console.Write("Press any key to continue . . . ");
      Console.ReadKey(true);
    }
  }
}