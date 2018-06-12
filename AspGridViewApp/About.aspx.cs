using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class About : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {        
        if(!IsPostBack)
        {            
            BindDropDown();
        }
    }

    private void BindGrid()
    {
        if (!Page.ClientScript.IsStartupScriptRegistered("PageUp"))
        {
            this.GridView1.DataSource = GetMeetingList();
            this.GridView1.DataBind();

            Page.ClientScript.RegisterStartupScript(this.GetType(), "PageUp", @"<script type='text/javascript'>ddValueChanged();</script>");
        }
    }

    private void BindDropDown()
    {
        var names = Enum.GetNames(typeof(DayOfWeek));
        var values = Enum.GetValues(typeof(DayOfWeek));

        this.ddlDays.DataSource = values;
        this.ddlDays.DataBind();
    }    
    
    private List<Meeting> GetMeetingList()
    {
        List<Meeting> meetings = new List<Meeting>();
        
        for(int i = 1; i <= 100; i++)
        {
            Meeting meeting = new Meeting()
            {
                ID = i,
                Name = "Meeting#" + i,
                Place = "meeting Place " + (i * 2),
                Code = Guid.NewGuid().ToString()
            };

            meetings.Add(meeting);
        }

        return meetings;
    }    

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GridView1.PageIndex = e.NewPageIndex;
        BindGrid();
    }

    protected void ddlDays_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();        
    }
}

public class Meeting
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Place { get; set; }
    public string Code { get; set; }
}