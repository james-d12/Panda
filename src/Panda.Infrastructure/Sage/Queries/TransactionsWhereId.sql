Select Cast(NT.UniqueReferenceNumber As int) as URN
		, NT.NLPostedNominalTranID as transactionId
        , Cast(NA.AccountNumber As Int) as accountNumber
        , NA.AccountName as accountName
        , NA.AccountCostCentre as accountCostCentre
        , NA.AccountDepartment as department
        , D.Name As departmentName
        , AP.PeriodNumber as periodNumber
        , NT.GoodsValueInBaseCurrency as goodsValue
        , Convert(date, NT.TransactionDate, 23) as transactionDate
        , NT.Reference as reference
		, NT.Narrative as narrative
        , NT.Source as source
    From NLPostedNominalTran NT
    Left Join SYSAccountingPeriod AP On AP.SYSAccountingPeriodID = NT.SYSAccountingPeriodID
    Left Join NLNominalAccount NA On NA.NLNominalAccountID = NT.NLNominalAccountID
    Left Join NLCostCentre CC On CC.NLCostCentreID = NA.NLCostCentreID
    Left Join NLDepartment D On D.NLDepartmentID = NA.NLDepartmentID
    Left Join SYSFinancialYear FY On FY.SYSFinancialYearID = AP.SYSFinancialYearID
    Join SYSAccountingPeriod CurAP On Convert(date, GetDate()) Between CurAP.StartDate And CurAP.EndDate
    Where 
      FY.YearRelativeToCurrentYear = 0 And
      NA.AccountNumber Not Like '0%' And 
      NT.GoodsValueInBaseCurrency Is Not Null And 
      (AP.PeriodNumber <= CurAp.PeriodNumber Or FY.YearRelativeToCurrentYear < 0) And
      NT.NLPostedNominalTranID In (@TransactionIds)
    Order By NA.AccountNumber
    , NA.AccountCostCentre
    , NA.AccountDepartment