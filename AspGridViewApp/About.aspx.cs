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
            BindGrid();
        }
    }

    private void BindGrid()
    {
        this.GridView1.DataSource = GetMeetingList();
        this.GridView1.DataBind();
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
                Place = "meeting Place " + (i * 2)
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
}

public class Meeting
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Place { get; set; }    
}