unit List;

interface

uses Monome, ListItem;

type

TList = class
  private
    fBegin, fStep: TListItem;
  public
    constructor Create;
    procedure AddItem (Data: TMonome);
    function Step: TMonome;
    function Find (power: integer): TMonome;
end;

implementation

constructor TList.Create;
begin
  fBegin := TListItem.Create;
  fStep := TListItem.Create;
end;

procedure TList.AddItem (Data: TMonome);
var
  NewItem, tempA, last, tempB: TListItem;
begin
  NewItem := TListItem.Create(Data);
  last := nil;
  if (fBegin = nil) then
    fBegin := NewItem
  else
    if (Data.XPower < fBegin.Data.XPower) then
      begin
        NewItem.next := fBegin;
        fBegin := NewItem;
      end
    else
      begin
        tempA := fBegin;
        while (tempA <> nil) do
          begin
            last:=tempA;
            if (tempA.Data.XPower = Data.XPower) then
              begin
                tempA.Data.Coefficient := Data.Coefficient;
                exit;
                break;
              end;
            if (tempA.next = nil) then
              begin
                tempA.next := NewItem;
                break;
              end;
            if ((tempA.next.Data.XPower > Data.XPower) and (tempA.Data.XPower < Data.XPower)) then
              begin
                tempB := tempA.next;
                tempA.next := NewItem;
                NewItem.next := tempB;
                break;
              end;
            tempA := tempA.next;
          end;
        if (tempA = nil) then
          last.next := NewItem;
      end;
    fStep := fBegin;
end;

function TList.Step: TMonome;
begin
  if (fStep = nil) then
    begin
      fStep := fBegin;
      Result := nil;
    end
  else
    begin
      Result := fStep.Data;
      fStep := fStep.next;
    end;
end;

function TList.Find (power: integer): TMonome;
var
  temp: TListItem;
begin
  temp := fBegin;
  while (temp <> nil) do
    begin
      if (temp.Data.XPower = power) then
        begin
          Result := temp.Data;
          exit;
        end;
      temp := temp.next;
    end;
  Result:=nil;
end;

end.
