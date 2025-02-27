﻿using System.Xml.Serialization;

namespace GCLocalServerRewrite.models;

[XmlType("ranking_status")]
public class RankStatus
{
    [XmlElement("table_name")] 
    public string TableName { get; set; } = "rank_table";

    [XmlElement("start_date")]
    public string StartDate { get; set; } = "2021-05-30";

    [XmlElement("end_date")]
    public string EndDate { get; set; } = "2022-06-08";

    [XmlElement("status")]
    public int Status { get; set; }

    [XmlElement("rows")]
    public int Rows { get; set; }
}