﻿using System.Data.SqlClient;

namespace NetQuax.Entities
{
  public class BillingInformation : IBillingInformation
  {
    #region fields

    private int _billingInformationId;
    private string _cardHolder;
    private string _cardNumber;
    private string _expDate;
    private int _securityCode;

    #endregion fields

    public BillingInformation(int billingId)
    {
      _billingInformationId = billingId;
      _cardNumber = null;
      _expDate = null;
      _securityCode = int.MinValue;
      _cardHolder = null;
    }

    public string CardHolder
    {
      get
      {
        if (_cardHolder == null && _billingInformationId > 0)
        {
          SqlDataReader reader = null;
          using (SqlConnection conn = new SqlConnection(Globals.connectionString))
          {
            conn.Open();
            string queryString = string.Format("SELECT cardHolder from BILLINGINFORMATION WHERE billingInformationId = {0}", _billingInformationId);
            SqlCommand cmd = new SqlCommand(queryString, conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
              _cardHolder = (string)reader[0];
            }
            conn.Close();
          }
          //TODO: Replace this with matching data
        }
        return _cardHolder;
      }
    }

    public string CardNumber
    {
      get
      {
        if (_cardNumber == null && _billingInformationId > 0)
        {
          SqlDataReader reader = null;
          using (SqlConnection conn = new SqlConnection(Globals.connectionString))
          {
            conn.Open();
            string queryString = string.Format("SELECT cardNumber from BILLINGINFORMATION WHERE billingInformationId = {0}", _billingInformationId);
            SqlCommand cmd = new SqlCommand(queryString, conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
              _cardNumber = (string)reader[0];
            }
            conn.Close();
          }
        }
        return _cardNumber;
      }
    }

    public string ExpDate
    {
      get
      {
        if (_expDate == null && _billingInformationId > 0)
        {
          SqlDataReader reader = null;
          using (SqlConnection conn = new SqlConnection(Globals.connectionString))
          {
            conn.Open();
            string queryString = string.Format("SELECT expDate from BILLINGINFORMATION WHERE billingInformationId = {0}", _billingInformationId);
            SqlCommand cmd = new SqlCommand(queryString, conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
              _expDate = (string)reader[0];
            }
            conn.Close();
          }
        }
        //TODO: Replace this with matching data
        return _expDate;
      }
    }

    public int SecurityCode
    {
      get
      {
        if (_securityCode <= 0 && _billingInformationId > 0)
        {
          SqlDataReader reader = null;
          using (SqlConnection conn = new SqlConnection(Globals.connectionString))
          {
            conn.Open();
            string queryString = string.Format("SELECT securityCode from BILLINGINFORMATION WHERE billingInformationId = {0}", _billingInformationId);
            SqlCommand cmd = new SqlCommand(queryString, conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
              _securityCode = (int)reader[0];
            }
            conn.Close();
          }
          //TODO: Replace this with matching data
        }
        return _securityCode;
      }
    }
  }
}