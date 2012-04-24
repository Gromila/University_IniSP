unit Monome;

interface

uses Math, SysUtils;

type
  TMonome = class
    private
      fCoefficient: extended;
      fPower: integer;

      procedure SetCoefficient (value: extended);
      function GetCoefficient: extended;

      procedure SetXPower (value: integer);
      function GetXPower: integer;

    public
      constructor Create;overload;                    //для класса
      constructor Create (coefficient: extended; XPower: integer);overload;//для монома

      function Calculate (value: extended): extended;  //вычисление для данного x
      function ToString: string;                      //перевод монома в строковый вид

      property Coefficient: extended read GetCoefficient write SetCoefficient;
      property XPower: integer read GetXPower write SetXPower;

      destructor Destroy;override;
  end;

implementation

constructor TMonome.Create;
begin

end;

constructor TMonome.Create(coefficient: extended; XPower: integer);
begin
  fCoefficient:=coefficient;
  fPower:=XPower;
end;

procedure TMonome.SetCoefficient (value:extended);
begin
  fCoefficient:=value;
end;

function TMonome.GetCoefficient: extended;
begin
  Result:=fCoefficient;
end;

procedure TMonome.SetXPower(value: integer);
begin
  fPower:=value;
end;

function TMonome.GetXPower: integer;
begin
  Result:=fPower;
end;

function TMonome.Calculate(value: extended): extended;
begin
  Result:=GetCoefficient*power(value, GetXPower);
end;

function TMonome.ToString: string;
begin
  if (GetCoefficient = 0.0) then
    Result:=''
  else
    Result:=FloatToStr(GetCoefficient)+'*x^'+FloatToStr(GetXPower);
  if (Length(Result) > 0) then
    begin
     if (Result[1] = '-') then
       Result:='-'+Copy(Result,2,Length(Result)-1)
      else Result:= '+'+Result;
    end;
end;

destructor TMonome.Destroy;
begin
end;

end.
