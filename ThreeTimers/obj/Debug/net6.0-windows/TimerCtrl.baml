   M S B A M L   `   `   `  ????F  BThreeTimers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ThreeTimersThreeTimers  5          ThreeTimers.TimerCtrl   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:ThreeTimers     5      .??5
      ? -   5          ?Name$  	TimerGrid??5
      
??????? ? RowDefinitions 5   
   ?? 5      $??40 ?6   6*   ?? 5      $??2 ?6   6)   ?? 5      $??40 ?6   6*   ?? 5      $??2 ?6   6)   ?? 5      $??40 ?6   6*   ?? 5      $??2 ?6   6)   ?? 5      $??40 ?6   6*   ?? 5      $??2 ?6   6)   ?? 5      $??40 ?6   6*   ?? 5      $??2 ?6   6)   ?? 5      $??40 ?6   6*   ?? 5      $??2 ?6   6)   ?? 5      $??40 ?6   6*   ?? 5      $??2 ?6   6)   ?? 5      $??40 ?6   6*    ? ColumnDefinitions 5   
   ?? 5      $	??200 ?6   6-   .+?5    
   ?? -   5         ??Name$ titleBar??5       $??Timer??6"   $??26(?62   
???   ?
???????$??Stretch=?5"      $??0??6,   $??0??69   $??Center=?5#      66   ?? 5%   
   -   5         ??Name$ tbClock??5%      $??00:00:00??6%   $??Consolas)?5&      $??28(?6*   $??Center=?5'      $??0??5(      $??2??6$   63   ?? 5*   
   -   5         ??Name$ btnStart??5*      $??Start Timer??6#   $??20(?69   $??4??5+      $??0??6   5,      ?? 5.   
   -   5        $ btnPause??5.      $??Pause Display??6#   $??20(?6;   $??6??5/      $??0??6   50      ?? 52   
   -   5        $ 	btnResume??52      $??Resume Display??6$   $??20(?6=   $??8??53      $??0??6   54      ?? 56   
   -   5        $??btnStop??56      $??
Stop Timer??6    $??20(?65   $??10??57      67   ?? 59   
   -   5        $ btnReset??59      $??Reset??6#   $??20(?63   $??12??5:      $??0??6   5;      ?? 5=   
   -	   5         ??Name$ 	TimerName??5=      $??20(?6&   $??14??5>      $??Center=?6!   .@?5?      ?? $??.Net 6 - Periodic??6    ?? 
IsSelected$
 True??67   6K   ?? 5@      $??Dispatcher Timer??6   $ False??66   6K   ?? 5A      $??Timers Timer??6   $ False??62   6G   5B      5E      5F      