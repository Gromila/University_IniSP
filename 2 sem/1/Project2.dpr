program Project2;

{$APPTYPE CONSOLE}

uses
  SysUtils, Polynome;

function Parse (str: string):TPolynome;
var
  coef: extended;
	power: integer;
	i: integer;
	temp: string;
begin
  Result:=TPolynome.Create;
	i:=1;
	while (i<=length(str)) do
	begin
    coef := 0;
		power := 0;
		temp:='';
    if ((i=1) and (str[i]='x')) then temp:='1'
    else
    begin
      if ((str[i] = '-') and (str[i+1]='x')) then
          temp:='-1'
      else
        if ((str[i] = '+') and (str[i+1]='x')) then
          temp:='1'
        else
		      while ((str[i]<>'*') and (i <= length(str))) do
		      begin
			      temp:=temp+str[i];
            i:=i+1;
		      end;
      i:=i+1;
    end;
    coef := StrToFloat(temp);
    temp:='';
		if (str[i] = 'x') then
			if (str[i+1]='^') then
			begin
				i:=i+2;
				while (str[i]<>'+') or (str[i]<>'-') do
				begin
					temp:=temp+str[i];
					i:=i+1;
          if ((str[i]='+') or (str[i]='-') or (i>length(str))) then break;
        end;
				power:= StrToInt (temp);
			end
			else
				if (str[i+1] = '+') or (str[i+1] = '-') or (i=length(str)) then
				begin
					power := 1;
					i:=i+1;
				end;
    Result.AddMonome(coef,power);
	end;
end;

var
  cmd,input: string;
  data1,data2: TPolynome;
  x: extended;
  menu: boolean;
begin
  { TODO -oUser -cConsole Main : Insert code here }
  menu := true;
  while (menu) do
  begin
    writeln('Available commands: add1 (add first polynome), add2 (add second polynome)');
    writeln('count1 (count first polynome), count2 (count second polynome)');
    writeln('print1 (print first polynome), print2 (print second polynome)');
    writeln('addition, subtract, multiply');
    writeln('exit');
    writeln;
    readln(cmd);
    writeln;
    if cmd = 'add1' then begin
              writeln('Enter first polynome (example: x^5+6*x^3+13');
              readln(input);
              data1:=Parse(input);
            end
    else if cmd = 'add2' then begin
              writeln('Enter second polynome');
              readln(input);
              data2:=Parse(input);
            end
    else if cmd = 'count1' then begin
              writeln('Enter x value:');
              readln(x);
              writeln('In x = '+FloatToStr(x)+' the value of polynome = '+FloatToStr(data1.Calculate(x)));
            end
    else if cmd = 'count2' then begin
                writeln('Enter x value:');
                readln(x);
                writeln('In x = '+FloatToStr(x)+' the value of polynome = '+FloatToStr(data2.Calculate(x)));
              end
    else if cmd = 'print1' then writeln(data1.ToString)
    else if cmd = 'print2' then writeln(data2.ToString)
    else if cmd = 'addition' then writeln('Result of addition: '+TPolynome.Addition(data1,data2).ToString)
    else if cmd = 'subtract' then writeln('Result of subtract: '+TPolynome.Subtract(data1,data2).ToString)
    else if cmd = 'multiply' then writeln('Result of multiply: '+TPolynome.Multiply(data1,data2).ToString)
    else if cmd = 'exit' then menu:=False
    else writeln('Error input. Try again.');
    writeln;
    writeln;
  end;
end.
